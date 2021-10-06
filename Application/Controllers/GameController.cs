using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Data.Models;
using Application.Models;
using Application.Repo;
using Application.Repo.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
/**
 * 
 * name         :   GameController.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Controllers
{
    /// <summary>
    /// This controller is responsible for displaying and getting data from the user related to the games.
    /// </summary>
    public class GameController : Controller
    {
        private readonly UnitOfWork _unitOfWork;

        public GameController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork as UnitOfWork;
        }

        /// <summary>
        /// This method returns view with all games stored in database
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<Game> list = _unitOfWork.GameRepositories.GetListOfGames();
            var model = AutoMapper.Mapper.Map<List<Game>, List<GameViewModel>>(list);
            return View(model.AsEnumerable());
        }

        /// <summary>
        /// Method return form to fill by user about new game or current game if id is provided and game exist
        /// </summary>
        /// <param name="id">Game id</param>
        /// <returns></returns>
        public IActionResult AddEdit(int? id)
        {
            GameViewModel model = new GameViewModel {Scores = new List<ScoreViewModel>()};
            TempData["Scores"] = JsonConvert.SerializeObject(model);
            if (id != null)
            {
                var game = _unitOfWork.MemberRepositories.FindGame((int) id);
                model = AutoMapper.Mapper.Map<Game, GameViewModel>(game);
                var gameScores = _unitOfWork.GameRepositories.GetGameScores(game);
                model.Scores = AutoMapper.Mapper.Map<List<Scores>, List<ScoreViewModel>>(gameScores);
                TempData["Scores"] = JsonConvert.SerializeObject(model);
            }

            return View(model);
        }
        /// <summary>
        /// Method executed after fill game form check correctness filled data and
        /// if is correct pass data to the repository to save them
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddEdit(GameViewModel model)
        {
            if (ModelState.IsValid)
            {
                var save = AutoMapper.Mapper.Map<GameViewModel, Game>(model);
                _unitOfWork.GameRepositories.AddUpdateGame(save, save.Scores);

                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        /// <summary>
        /// Method retrieves data from repository about specific game and return view with this data 
        /// </summary>
        /// <param name="id">Game id</param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var result = _unitOfWork.GameRepositories.GetById(id);
            var model = AutoMapper.Mapper.Map<Game, GameViewModel>(result);

            return View(model);
            
        }
        /// <summary>
        /// Method removes the game
        /// </summary>
        /// <param name="id">Game id</param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            _unitOfWork.GameRepositories.DeleteGame(id);
            return RedirectToAction(nameof(Index));
            
        }

        /// <summary>
        /// Method return form of Score for new or exist score
        /// </summary>
        /// <param name="id">Score id</param>
        /// <returns></returns>
        public IActionResult AddScore(int? id)
        {
            var model = new ScoreViewModel();

            if (id != null)
            {
                TempData.TryGetValue("Scores", out object value);
                var data = value as string ?? "";
                var list = JsonConvert.DeserializeObject<GameViewModel>(data) ??
                           new GameViewModel();
                model = list.Scores.ElementAt((int) id);
                TempData["ScoresID"] = id;
                string json = JsonConvert.SerializeObject(list);
                TempData["Scores"] = json;
            }
            else
            {
                TempData["ScoresID"] = null;
            }


            return PartialView("_AddScore", model);
        }

        /// <summary>
        /// Method on submit score add score to list for later save
        /// </summary>
        /// <param name="model">Data form js form</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddScore(ScoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                TempData.TryGetValue("Scores", out object value);
                var data = value as string ?? "";
                var list = JsonConvert.DeserializeObject<GameViewModel>(data) ??
                           new GameViewModel();
                if (list.Scores == null)
                    list.Scores = new List<ScoreViewModel>();
                TempData.TryGetValue("ScoresID", out object listIndex);
                listIndex = listIndex as int? ?? null;
                if (listIndex != null)
                {
                    list.Scores[(int) listIndex] = model;
                }
                else
                {
                    list.Scores.Add(model);
                }


                string json = JsonConvert.SerializeObject(list);
                TempData["Scores"] = json;
            }

            return PartialView("_AddScore", model);
        }

        /// <summary>
        /// Method delete score form temp list 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> DeleteScore(int id)
        {
            DeleteScoreFromList(id);
            return true;
        }
        /// <summary>
        /// Method delete score form temp list 
        /// </summary>
        /// <param name="id"></param>
        private void DeleteScoreFromList(int id)
        {
            TempData.TryGetValue("Scores", out object value);
            var data = value as string ?? "";
            var list = JsonConvert.DeserializeObject<GameViewModel>(data) ??
                       new GameViewModel();
            list.Scores.RemoveAt(id);
            string json = JsonConvert.SerializeObject(list);
            TempData["Scores"] = json;
        }

        /// <summary>
        /// Method return view with table of scores 
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public IActionResult ModalFillTable(string table = null)
        {
            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest" && table == "Scores")
            {
                var scorePartialList = OnAjaxScoreTablePartialViewResult();
                return PartialView("_ScoreTable", scorePartialList);
            }

            return null;
        }

        /// <summary>
        /// Method generate table with scores, based on temp data 
        /// </summary>
        /// <returns></returns>
        [NonAction]
        private GameViewModel OnAjaxScoreTablePartialViewResult()
        {
            TempData.TryGetValue("Scores", out object value);
            var data = value as string ?? "";
            var table = JsonConvert.DeserializeObject<GameViewModel>(data) ??
                        new GameViewModel();
            if (table.Scores == null)
                table.Scores = new List<ScoreViewModel>();
            TempData["Scores"] = JsonConvert.SerializeObject(table);
            table.Scores = table.Scores.OrderBy(x => x.Half).ToList();
            return table;
        }
    }
}