using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20章视图.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = "Hello,word";
            ViewBag.Time = DateTime.Now.ToShortTimeString();
            return View("DebugData");
        }
        public ActionResult List()
        {
            string[] names = { "Apple", "Orange", "Pear" };
            return View(names);
        }
        [ChildActionOnly]
        public ActionResult Time()
        {
            return PartialView(DateTime.Now);
        }
    }
}