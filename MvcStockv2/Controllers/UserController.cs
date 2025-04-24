using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcStockv2.Models.Entity;
using MvcStock.Models.ViewModel;
using System.Security.Cryptography.Xml;
using System.Diagnostics;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Identity;
namespace MvcStock.Controllers
{
    public class UserController : Controller
    {
        Logiconnectv2Context db = new Logiconnectv2Context();
        List<RegisterViewModel> registerViewModel = new List<RegisterViewModel>();
        //Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string UserName, string password)
        {
            if (ModelState.IsValid)
            {
                var User = db.Kullanıcıs.ToList();
                var findUser = User.Where(s => s.UserName == UserName).FirstOrDefault();
                if (findUser != null)
                {
                    var findPassword = User.Where(x => x.UserName == UserName && x.Password == password).FirstOrDefault();


                    if (findPassword != null)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }


            }
            ViewData["ErrorMessage"] = "Username or password is incorrect";
            return View("Login");

        }

        public IActionResult Register()
        {
            
            return View();

        }

        //Register
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                Kullanıcı user = new Kullanıcı();
                user.UserName = model.UserName;
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.Password = model.Password;
                user.Email = model.EMail;
                db.Kullanıcıs.Add(user);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Registration successful! You can now log in.";
                return RedirectToAction("Login");
            }
            return RedirectToAction("Register");
        }

    }
}
