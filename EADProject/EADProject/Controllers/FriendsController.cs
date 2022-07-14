using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EADProject.Controllers
{
    public class FriendsController : Controller
    {
        public IActionResult FriendAndRequests()
        {
            ViewBag.page = "Friend";
            return View();
        }
    }
}
