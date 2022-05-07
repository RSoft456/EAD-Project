using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EADProject.Models;

namespace EADProject.Controllers
{
    public class StartController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("SignUp", "User");
        }
    }
}
