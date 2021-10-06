using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Data.Models;
using Application.Models;
using Application.Repo;
using Application.Repo.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
/**
 * 
 * name         :   TrainingController.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Controllers
{
    /// <summary>
    /// This controller is responsible for displaying and getting data from the user related to the Trainings.
    /// </summary>
    public class TrainingController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public TrainingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }

        /// <summary>
        /// This method returns view with all trainings stored in database
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var listOfTrainings = _unitOfWork.TrainingRepositories.GetListOfTrainings();
            var model = AutoMapper.Mapper.Map<List<Training>, List<TrainingViewModel>>(listOfTrainings);
            return View(model);
        }

        /// <summary>
        /// Method return form to create new training
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            var model = new TrainingViewModel()
            {
                Activities = new List<ActivitiesViewModel>()
            };
            TempData["Activities"] = JsonConvert.SerializeObject(model);

            ViewBag.PlayerList =
                AutoMapper.Mapper.Map<List<Member>, List<MemberViewModel>>(
                    _unitOfWork.MemberRepositories.GetPlayerList());


            ViewBag.CoachList = _unitOfWork.TrainingRepositories.GetListOfCoaches();
            return View(model);
        }

        /// <summary>
        /// Method check correctness of training data and save to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(TrainingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var save = AutoMapper.Mapper.Map<TrainingViewModel, Training>(model);
                _unitOfWork.TrainingRepositories.AddUpdateTraining(save, save.Activities);
                _unitOfWork.TrainingRepositories.InsertUpdateAttendance(save, model.Attended);
                return RedirectToAction(nameof(Index));
            }


            return View(model);
        }
        /// <summary>
        /// Method return form to edit exiting training
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit(int id)
        {
            ViewBag.PlayerList =
                AutoMapper.Mapper.Map<List<Member>, List<MemberViewModel>>(
                    _unitOfWork.MemberRepositories.GetPlayerList());

            ViewBag.CoachList = _unitOfWork.TrainingRepositories.GetListOfCoaches();
            var training = _unitOfWork.TrainingRepositories.GetTraining(id);
            var model = AutoMapper.Mapper.Map<Training, TrainingViewModel>(training);
            model.Attended = _unitOfWork.TrainingRepositories.GetSelectedAttendance(training);
            TempData["Activities"] = JsonConvert.SerializeObject(model);
            return View("Create", model);
        }
        /// <summary>
        /// Method check correctness of training data and save to database
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(TrainingViewModel model)
        {
            if (ModelState.IsValid)
            {
                var save = AutoMapper.Mapper.Map<TrainingViewModel, Training>(model);
                _unitOfWork.TrainingRepositories.AddUpdateTraining(save, save.Activities);
                _unitOfWork.TrainingRepositories.InsertUpdateAttendance(save, model.Attended);

                return RedirectToAction(nameof(Index));
            }


            return View("Create", model);
        }

         /// <summary>
         /// Method retrieves data from repository about specific training and return view with this data 
         /// </summary>
         /// <param name="Id"></param>
         /// <returns></returns>
        public IActionResult Details(int Id)
        {
            var result = _unitOfWork.TrainingRepositories.GetTraining(Id);
            var model = AutoMapper.Mapper.Map<Training, TrainingViewModel>(result);

            List<Member> attendanceList = _unitOfWork.TrainingRepositories.GetAttendenceList(result.Id);
            model.Attendance = AutoMapper.Mapper.Map<List<Member>, List<MemberViewModel>>(attendanceList);
            return View(model);
        }

        /// <summary>
        /// Method removes the training
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IActionResult Delete(int Id)
        {
            _unitOfWork.TrainingRepositories.DeleteTrainingById(Id);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Method return form to add or edit Activity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult AddActivity(int? id)
        {
            var model = new ActivitiesViewModel();

            if (id != null)
            {
                TempData.TryGetValue("Activities", out object value);
                var data = value as string ?? "";
                var list = JsonConvert.DeserializeObject<TrainingViewModel>(data) ??
                           new TrainingViewModel();
                model = list.Activities.ElementAt((int) id);
                TempData["ActivitiesID"] = id;
                string json = JsonConvert.SerializeObject(list);
                TempData["Activities"] = json;
            }
            else
            {
                TempData["ActivitiesID"] = null;
            }


            return PartialView("_ActivityAddForm", model);
        }

        /// <summary>
        /// Method check form to add or edit Activity and save it if correct
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddActivity(ActivitiesViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData.TryGetValue("Activities", out object value);
                var data = value as string ?? "";
                var list = JsonConvert.DeserializeObject<TrainingViewModel>(data) ??
                           new TrainingViewModel();
                if (list.Activities == null)
                    list.Activities = new List<ActivitiesViewModel>();
                TempData.TryGetValue("ActivitiesID", out object listIndex);
                listIndex = listIndex as int? ?? null;
                if (listIndex != null)
                {
                    list.Activities[(int) listIndex] = model;
                }
                else
                {
                    list.Activities.Add(model);
                }


                string json = JsonConvert.SerializeObject(list);
                TempData["Activities"] = json;
            }

            return PartialView("_ActivityAddForm", model);
        }

        /// <summary>
        /// Method generate table with Activities
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public IActionResult ModalFillTable(string table = null)
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest" && table == "Activity")
            {
                var activityPartialList = OnAjaxActivityTablePartialViewResult();
                return PartialView("_ActivitiesTable", activityPartialList);
            }

            return null;
        }

        /// <summary>
        /// Method return list of Activities form temp data
        /// </summary>
        /// <returns></returns>
        private TrainingViewModel OnAjaxActivityTablePartialViewResult()
        {
            TempData.TryGetValue("Activities", out object value);
            var data = value as string ?? "";
            var table = JsonConvert.DeserializeObject<TrainingViewModel>(data) ??
                        new TrainingViewModel();
            if (table.Activities == null)
                table.Activities = new List<ActivitiesViewModel>();
            TempData["Activities"] = JsonConvert.SerializeObject(table);
            return table;
        }


        /// <summary>
        /// Method delete from temp data specific activity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> DeleteActivity(int id)
        {
            DeleteActivityFromList(id);
            return true;
        }
        
        /// <summary>
        /// Method delete from temp data specific activity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DeleteActivityFromList(int id)
        {
            TempData.TryGetValue("Activities", out object value);
            var data = value as string ?? "";
            var list = JsonConvert.DeserializeObject<TrainingViewModel>(data) ??
                       new TrainingViewModel();
            list.Activities.RemoveAt(id);
            string json = JsonConvert.SerializeObject(list);
            TempData["Activities"] = json;
            return true;
        }
    }
}