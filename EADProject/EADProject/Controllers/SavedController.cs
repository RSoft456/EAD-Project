using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADProject.Controllers
{
    public class SavedController : Controller
    {
        public IActionResult SavedItems()
        {
            ViewBag.page = "Saved";
            return View();
        }
    }
}
