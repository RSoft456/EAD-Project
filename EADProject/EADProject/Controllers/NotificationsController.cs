using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADProject.Controllers
{
    public class NotificationsController : Controller
    {
        public IActionResult Notifications()
        {
            ViewBag.page = "Notification";
            return View();
        }
    }
}
