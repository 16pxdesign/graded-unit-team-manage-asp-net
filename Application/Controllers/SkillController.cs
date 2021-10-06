using System;
using System.Collections.Generic;
using Application.Data.Models;
using Application.Models;
using Application.Repo;
using Application.Repo.Contracts;
using Microsoft.AspNetCore.Mvc;
/**
 * 
 * name         :   SkillController.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Controllers
{
    /// <summary>
    /// This controller is responsible for displaying and getting data from the user related to the Skills and Skills categories.
    /// </summary>
    public class SkillController : Controller
    {
        
        private readonly UnitOfWork _unitOfWork;

        public SkillController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }
        
        /// <summary>
        /// Method return list of all categories and skills
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<Skill> list = _unitOfWork.ProfileRepository.GetSkillList();
            var model = AutoMapper.Mapper.Map<List<Skill>, List<SkillViewModel>>(list);
            return View(model);
        }

      

        /// <summary>
        /// Method return form to add or edit skill or category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult AddEdit(int? id)
        {
            var model = new SkillViewModel();

            if (id != null)
            {
                Skill skill = _unitOfWork.ProfileRepository.GetSkillById((int) id);
                model = AutoMapper.Mapper.Map<Skill, SkillViewModel>(skill);
            }

           
                var categoryList =_unitOfWork.ProfileRepository.GetCategories();
                model.Categories = AutoMapper.Mapper.Map<List<Skill>, List<SkillViewModel>>(categoryList);
            
                
         
            return View(model);
        }

        /// <summary>
        /// Method check and save passed form data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddEdit(SkillViewModel model)
        {

            if (ModelState.IsValid)
            {
                var skill = AutoMapper.Mapper.Map<SkillViewModel,Skill>(model);
                _unitOfWork.ProfileRepository.AddUpdateSkill(skill);
                
                
                return RedirectToAction(nameof(Index));
            }
            
            
            return View(model);
        }

        /// <summary>
        /// Method delete skill or category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.ProfileRepository.DeleteSkill(id);
                return RedirectToAction(nameof(Index));

            }
            catch (Exception e)
            {
                return View(e);
            }
        }
    }
}