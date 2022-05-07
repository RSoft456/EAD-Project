using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EADProject.Models;

namespace EADProject.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(User u)
        {
            string message = string.Empty;
            if (u.Password == u.ConfirmPassword)
            {
                UserRepository user = new UserRepository();
                message = user.AddUser(u);
                ViewBag.msg = message;
                if (message == "Signed Up Successfully")
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    return View("SignUp");
                }
            }
            else
            {
                message = "Unmatched Passwords";
                ViewBag.msg = message;
                return View("SignUp");
            }
        }
        [HttpPost]
        public IActionResult SignIn(User u)
        {
            User SearchedUser = new User();
            UserRepository user = new UserRepository();
            SearchedUser = user.searchUser(u);
            ViewBag.user = SearchedUser;
            if (SearchedUser.UserName != "" && SearchedUser.Password != "")
            {
               return RedirectToAction("UserData", "Home");
            }
            else
            {
                ViewBag.loginMessage = "Wrong Password or UserName";
                return View("SignIn");
            }
        }
    }
}
