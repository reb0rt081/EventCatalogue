using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        /// <summary>
        /// All web pages are created here.
        /// A CSHTML file with the same name must exist in views.
        /// </summary>
        /// <returns></returns>
        public ActionResult EventsHome()
        {
            ViewBag.Title = "EventsHome Page";

            return View();
        }
    }
}
