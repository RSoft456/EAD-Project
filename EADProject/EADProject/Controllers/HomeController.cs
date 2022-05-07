using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EADProject.Models;

namespace EADProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult UserData()
        {
            List<User> data = new List<User>();
            UserRepository user = new UserRepository();
            data = user.GetAllUsers();
            ViewBag.x = data;
            return View();
        }
    }
}
