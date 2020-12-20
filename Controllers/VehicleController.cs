using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace User_System_Test_App.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult Index(int userId)
        {
            return View();
        }
    }
}