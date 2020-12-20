using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User_System_Test_App.Models;

namespace User_System_Test_App.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index(UserModel user)
        {
            ViewData["createMode"] = false;
            return View();
        }

        public ActionResult Index()
        {
            ViewData["createMode"] = true;
            return View();
        }
    }
}