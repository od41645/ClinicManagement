using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicWeb.Controllers
{
    public class StartupController : Controller
    {
        // GET: Startup
        public ActionResult Index()
        {
            return View();
        }
    }
}