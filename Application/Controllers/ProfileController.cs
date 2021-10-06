using System;
using System.Collections.Generic;
using System.Linq;
using Application.Data.Models;
using Application.Models;
using Application.Repo;
using Application.Repo.Contracts;
using Microsoft.AspNetCore.Mvc;
/**
 * 
 * name         :   ProfileController.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Controllers
{
    /// <summary>
    /// This controller is responsible for displaying and getting data from the user related to the player evaluation.
    /// </summary>
    public class ProfileController : Controller
    {
        
        private readonly UnitOfWork _unitOfWork;

        public ProfileController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }

        /// <summary>
        /// Method return view with all players 
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var memberList = _unitOfWork.MemberRepositories.GetPlayerList();
            var list = AutoMapper.Mapper.Map<List<Member>, List<MemberViewModel>>(memberList);
            return View(list);
        }

        /// <summary>
        /// Method return view with evaluation form for specific player
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Evaluate(string id)
        {
            if (id == null )
            {
                return RedirectToAction(nameof(Index));

            }else if (!_unitOfWork.MemberRepositories.IsPlayer(id))
            {
                return RedirectToAction(nameof(Index));
            }
            
            var model = new EvalutationViewModel();
          
       
            var playerRaw = _unitOfWork.MemberRepositories.FindBySRU(id);
            model.Player = AutoMapper.Mapper.Map<Member, MemberShortViewModel>(playerRaw);
            
            List<Profile> skillsScores = _unitOfWork.ProfileRepository.GetPlayerSkillsScores(id);
            model.Scores = AutoMapper.Mapper.Map<List<Profile>, List<ProfileViewModel>>(skillsScores);
            
            model.Categories = AutoMapper.Mapper.Map<List<Skill>,List<SkillViewModel>>( _unitOfWork.ProfileRepository.GetCategories());
            model.Skills = AutoMapper.Mapper.Map<List<Skill>,List<SkillViewModel>>( _unitOfWork.ProfileRepository.GetSkills());
            
       

            return View(model);
        }

        /// <summary>
        /// Method save passed player evaluation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Evaluate(EvalutationViewModel model)
        {
            ModelState.Remove("Player");
            ModelState.Remove("Categories");
            ModelState.Remove("Skills");
            
            if (ModelState.IsValid)
            {
                if (model.Scores!= null && model.Scores.Any())
                {
                    
                    var profiles = AutoMapper.Mapper.Map<List<ProfileViewModel>,List<Profile>>(model.Scores);
                    _unitOfWork.ProfileRepository.SaveListOfScores(profiles);
                }
               
                return RedirectToAction(nameof(Index));
            }
            
            var playerRaw = _unitOfWork.MemberRepositories.FindBySRU(model.Player.SRU);
            model.Player = AutoMapper.Mapper.Map<Member, MemberShortViewModel>(playerRaw);
            
     
            model.Categories = AutoMapper.Mapper.Map<List<Skill>,List<SkillViewModel>>( _unitOfWork.ProfileRepository.GetCategories());
            model.Skills = AutoMapper.Mapper.Map<List<Skill>,List<SkillViewModel>>( _unitOfWork.ProfileRepository.GetSkills());
            
            return View(model);
            
        }

    }
}