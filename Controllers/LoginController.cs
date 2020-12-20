using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using User_System_Test_App.Models;

namespace User_System_Test_App.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            if (ViewData["ShowTooltip"] == null) ViewData["ShowTooltip"] = false;
            return View();
        }

        [HttpPost]
        public ActionResult Index(string login_email, string login_password)
        {
            VerifyConceptModel concept = new VerifyConceptModel() { Email = login_email, Password = login_password };
            

            DatabaseModel database = new DatabaseModel(Properties.Resources.SqlConnectionString);
            int output = database.RunSproc("dbo.validate_user", ("email", concept.Email), ("pass", concept.Password));
            

            if (output >= 0)
            {
                DataTable userTable = database.RunSprocSet("dbo.get_user", ("id", output));
                UserModel user = new UserModel(userTable, output);
                Session["user"] = user;
                return RedirectToAction("Index", "Home", new { area = "" });
            }

            ViewData["Tooltip"] = "Incorrect email or password.";
            ViewData["ShowTooltip"] = true;
            return View();
        }
    }
}