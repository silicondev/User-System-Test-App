using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User_System_Test_App.Models;

namespace User_System_Test_App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["userId"] == null)
                return RedirectToAction("Index", "Login", new { area = "" });


            DatabaseModel database = new DatabaseModel(Properties.Resources.SqlConnectionString);
            DataSet users = database.RunSprocSet("print_users", "Users");

            ViewData["Users"] = users;

            return View();
        }
    }
}