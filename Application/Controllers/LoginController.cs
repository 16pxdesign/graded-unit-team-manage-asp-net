using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
/**
 * 
 * name         :   LoginController.cs
 * author       :   Aleksy Ruszala
 * date         :   29/04/2019
 *
 * */
namespace Application.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginViewModel _login;

        public LoginController()
        {
            _login = new LoginViewModel() { Password = "123456" };
        }
       /// <summary>
       /// Display login panel
       /// </summary>
       /// <returns></returns>
        public IActionResult Index()
        {
            
            return View();
        }
        /// <summary>
        /// Method check passed password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if ( model.Password.Equals(_login.Password))
                {
                    HttpContext.Session.SetString("Auth", "login");
                    return RedirectToAction("Index", "Index", null);

                }
                
                ModelState.AddModelError("Password","Wrong password");

                
            }

            return View();
        }
        /// <summary>
        /// Method remove logout current user
        /// </summary>
        /// <returns></returns>
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("Auth");
            return RedirectToAction("Index");
        }
    }
}