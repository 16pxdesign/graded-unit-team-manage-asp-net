using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Application.Repo.Contracts;
using Application.Data.Models;
using Application.Repo;
using Newtonsoft.Json;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using ModelStateDictionary = Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;
using ViewResult = System.Web.Mvc.ViewResult;

/**
 * 
 * name         :   MemberController.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Controllers
{
    /// <summary>
    /// This controller is responsible for displaying and getting data from the user related to the members.
    /// </summary>
    public class MemberController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public MemberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }

        /// <summary>
        /// Method return view with form for new or existing member if id is provided
        /// </summary>
        /// <param name="id">Member SRU</param>
        /// <param name="table"></param>
        /// <returns></returns>
        public IActionResult CreateUpdate(string id = null, string table = null)
        {

            MemberViewModel model = null;

            TempData["EditMember"] = false;
            if (id != null)
            {
                TempData["EditMember"] = true;
                var member = _unitOfWork.MemberRepositories.FindBySRU(id);
                model = AutoMapper.Mapper.Map<Member, MemberViewModel>(member);
            }


            if (model == null)
                model = new MemberViewModel();

            TempData["HealthIssues"] = JsonConvert.SerializeObject(model.Player);
            TempData["Guardians"] = JsonConvert.SerializeObject(model.Player.Junior);

            return View(model);
        }

        /// <summary>
        /// Method check data from member form and try to save new or update existing member
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateUpdate(MemberViewModel model)
        {
            if (model.Type == MemberType.Member)
            {
                IgnoreModelStateProperty(ModelState, "Player");
            }

            if (model.Type == MemberType.Junior)
            {
                IgnoreModelStateProperty(ModelState, "Player.Senior");
            }

            if (model.Type == MemberType.Senior)
            {
                IgnoreModelStateProperty(ModelState, "Player.Junior");
            }

            if (ModelState.IsValid)
            {
                
                bool isEdit = (bool) (TempData["EditMember"] ?? false);
                TempData["EditMember"] = isEdit;
                var member = AutoMapper.Mapper.Map<MemberViewModel, Member>(model);
          
                if (isEdit)
                {
                    try
                    {
                        _unitOfWork.MemberRepositories.InsertEditMember(member);
                    }
                    catch (Exception e)
                    {
                        return View("MemberRelation",
                            new Exception(
                                "Can not to do modification on member if member is assigned to any training or other page"));
                    }

                    return RedirectToAction(nameof(Index));
                }
                
                if (_unitOfWork.MemberRepositories.IsMemberExist(member.SRU))
                {
                    ModelState.AddModelError("SRU", "User with this SRU exist");
                    return View(model);
                }
                
                _unitOfWork.MemberRepositories.InsertEditMember(member);
                return RedirectToAction(nameof(Index));

            }

            return View(model);
        }
        
        /// <summary>
        /// Method return view with table of health issues or guardians 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public IActionResult ModalFillTable(string table = null)
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest" && table == "Health")
            {
                var healthIssuePartialList = OnAjaxHealthTablePartialViewResult();
                return PartialView("_HealthTable", healthIssuePartialList);
            }

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest" && table == "Guardian")
            {
                var guardianPartialList = OnAjaxGuardianPartialViewResult();
                return PartialView("_GuardianTable", guardianPartialList);
            }

            return null;
        }

        /// <summary>
        /// Method set ModelState properties to ignore
        /// </summary>
        /// <param name="modelState"></param>
        /// <param name="key"></param>
        private void IgnoreModelStateProperty(ModelStateDictionary modelState, string key)
        {
            foreach (var modelError in modelState)
            {
                string propertyName = modelError.Key;

                if (propertyName.Contains(key))
                {
                    ModelState[propertyName].Errors.Clear();
                    //Remove to make State valid
                    ModelState.Remove(propertyName);
                }
            }
        }


        /// <summary>
        /// Method generate table with Health Issues, based on temp data 
        /// </summary>
        /// <returns></returns>
        [NonAction]
        private PlayerViewModel OnAjaxHealthTablePartialViewResult()
        {
            TempData.TryGetValue("HealthIssues", out object value);
            var data = value as string ?? "";
            var playerWithIssues = JsonConvert.DeserializeObject<PlayerViewModel>(data) ??
                        new PlayerViewModel();
            if (playerWithIssues.HealthIssues == null)
                playerWithIssues.HealthIssues = new List<HealthIssueViewModel>();
            TempData["HealthIssues"] = JsonConvert.SerializeObject(playerWithIssues);
            return playerWithIssues;
        }

        /// <summary>
        /// Method return view for new or exist Health Issues form 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult AddHealth(int? id)
        {
            var model = new HealthIssueViewModel();

            if (id != null)
            {
                TempData.TryGetValue("HealthIssues", out object value);
                var data = value as string ?? "";
                var list = JsonConvert.DeserializeObject<PlayerViewModel>(data) ??
                           new PlayerViewModel();
                model = list.HealthIssues.ElementAt((int) id);
                TempData["HealthIssuesID"] = id;
                string json = JsonConvert.SerializeObject(list);
                TempData["HealthIssues"] = json;
            }
            else
            {
                TempData["HealthIssuesID"] = null;
            }


            return PartialView("_HealthAddForm", model);
        }

        /// <summary>
        /// Method on submit add Health Issue to list for later save
        /// </summary>
        /// <param name="model">Data form js form</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddHealth(HealthIssueViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData.TryGetValue("HealthIssues", out object value);
                var data = value as string ?? "";
                var list = JsonConvert.DeserializeObject<PlayerViewModel>(data) ??
                           new PlayerViewModel();
                if (list.HealthIssues == null)
                    list.HealthIssues = new List<HealthIssueViewModel>();
                TempData.TryGetValue("HealthIssuesID", out object listIndex);
                listIndex = listIndex as int? ?? null;
                if (listIndex != null)
                {
                    list.HealthIssues[(int) listIndex] = model;
                }
                else
                {
                    list.HealthIssues.Add(model);
                }


                string json = JsonConvert.SerializeObject(list);
                TempData["HealthIssues"] = json;
            }

            return PartialView("_HealthAddForm", model);
        }

        /// <summary>
        /// Method delete form temp list Health Issue
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> DeleteHealth(int id)
        {
            DeleteHealthFromList(id);
            return true;
        }
        /// <summary>
        /// Method delete form temp list Health Issue
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DeleteHealthFromList(int id)
        {
            TempData.TryGetValue("HealthIssues", out object value);
            var data = value as string ?? "";
            var list = JsonConvert.DeserializeObject<PlayerViewModel>(data) ??
                       new PlayerViewModel();
            list.HealthIssues.RemoveAt(id);
            string json = JsonConvert.SerializeObject(list);
            TempData["HealthIssues"] = json;
            return true;
        }
        /// <summary>
        /// Method return view for new or exist Guardian form 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult AddGuardian(int? id)
        {
            var model = new GuardianViewModel();

            if (id != null)
            {
                TempData.TryGetValue("Guardians", out object value);
                var data = value as string ?? "";
                var list = JsonConvert.DeserializeObject<JuniorViewModel>(data) ??
                           new JuniorViewModel();
                model = list.Guardians.ElementAt((int) id);
                TempData["GuardiansID"] = id;
                string json = JsonConvert.SerializeObject(list);
                TempData["Guardians"] = json;
            }
            else
            {
                TempData["GuardiansID"] = null;
            }


            return PartialView("_GuardianAddForm", model);
        }

        /// <summary>
        /// Method on submit add Guardian to list for later save
        /// </summary>
        /// <param name="model">Data form js form</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddGuardian(GuardianViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData.TryGetValue("Guardians", out object value);
                var data = value as string ?? "";
                var list = JsonConvert.DeserializeObject<JuniorViewModel>(data) ??
                           new JuniorViewModel();
                if (list.Guardians == null)
                    list.Guardians = new List<GuardianViewModel>();

                TempData.TryGetValue("GuardiansID", out object listIndex);
                listIndex = listIndex as int? ?? null;
                if (listIndex != null)
                {
                    list.Guardians[(int) listIndex] = model;
                }
                else
                {
                    list.Guardians.Add(model);
                }


                string json = JsonConvert.SerializeObject(list);
                TempData["Guardians"] = json;
            }

            return PartialView("_GuardianAddForm", model);
        }
        /// <summary>
        /// Method delete form temp list Guardian
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> DeleteGuardian(int id)
        {
            await DeleteGuardianFromList(id);
            return true;
        }
        /// <summary>
        /// Method delete form temp list Guardian
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<bool> DeleteGuardianFromList(int id)
        {
            TempData.TryGetValue("Guardians", out object value);
            var data = value as string ?? "";
            JuniorViewModel list = JsonConvert.DeserializeObject<JuniorViewModel>(data) ??
                                   new JuniorViewModel();
            if (list.Guardians == null)
                list.Guardians = new List<GuardianViewModel>();

            list.Guardians.RemoveAt(id);
            string json = JsonConvert.SerializeObject(list);
            TempData["Guardians"] = json;
            return true;
        }

        /// <summary>
        /// Method return table of Guardian
        /// </summary>
        /// <returns></returns>
        [NonAction]
        private JuniorViewModel OnAjaxGuardianPartialViewResult()
        {
            TempData.TryGetValue("Guardians", out object value);
            var data = value as string ?? "";
            JuniorViewModel table = JsonConvert.DeserializeObject<JuniorViewModel>(data) ??
                                    new JuniorViewModel();
            TempData["Guardians"] = JsonConvert.SerializeObject(table);

            return table;
        }

        /// <summary>
        /// This method returns view with all members stored in database
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var memberList = _unitOfWork.MemberRepositories.GetMemberList();
            var list = AutoMapper.Mapper.Map<List<Member>, List<MemberViewModel>>(memberList);
            return View(list);
        }

        /// <summary>
        /// Method retrieves data from repository about specific member and return view with this data 
        /// </summary>
        /// <param name="id">Game id</param>
        /// <returns></returns>
        public IActionResult Details(string sru)
        {
            var member = _unitOfWork.MemberRepositories.FindBySRU(sru);
            var model = AutoMapper.Mapper.Map<Member, MemberViewModel>(member);
            return View(model);
        }

        public IActionResult Delete(string sru)
        {
            try
            {
                _unitOfWork.MemberRepositories.DeleteBySRU(sru);

            }
            catch (Exception e)
            {
                return View("MemberRelation",new Exception("Can not to do modification on member if member is assigned to any training or other page"));
            }
            return RedirectToAction(nameof(Index));
        }

    
    }
}