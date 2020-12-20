using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace User_System_Test_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["userId"] == null)
                return RedirectToAction("Index", "Login", new { area = "" });

            return View();
        }
    }
}