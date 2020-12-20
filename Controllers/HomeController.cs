using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User_System_Test_App.Models;
using User_System_Test_App.ViewModel;

namespace User_System_Test_App.Controllers
{
    public class HomeController : Controller
    {
        private DatabaseModel _database;
        private bool _needsRefresh = true;
        public ActionResult Index()
        {
            if (Session["user"] == null)
                return RedirectToAction("Index", "Login", new { area = "" });


            if (_needsRefresh)
            {
                _database = new DatabaseModel(Properties.Resources.SqlConnectionString);
                DataTable users = _database.RunSprocSet("print_users");

                ViewData["Users"] = users;
                _needsRefresh = false;
            }

            return View();
        }

        public ActionResult Result(string add, string edit, string delete, string logout)
        {
            if (!string.IsNullOrEmpty(add))
                return AddUser();
            if (!string.IsNullOrEmpty(edit))
                return EditUser();
            if (!string.IsNullOrEmpty(delete))
                return DeleteUser();
            if (!string.IsNullOrEmpty(logout))
                return Logout();
            return View();
        }

        private ActionResult AddUser()
        {
            return RedirectToAction("Index", "User", new { area = "" });
        }

        private ActionResult EditUser()
        {
            var radio = Request.Form["select"];
            int id = int.Parse(radio);
            DataTable users = _database.RunSprocSet("get_user", ("id", id));
            UserModel user = new UserModel(users, id);
            return RedirectToAction("Index", "User", new { area = "", user });
        }

        private ActionResult DeleteUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditVehicles(int id)
        {
            return View();
        }

        private ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Login", new { area = "" });
        }
    }
}