using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADProject.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult UserPage()
        {
            return View();
        }
        public IActionResult settingsPage()
        {
            return View();
        }
    }
}
