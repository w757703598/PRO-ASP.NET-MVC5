using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 精通ASP.NETmvc5.Models;

namespace 精通ASP.NETmvc5.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "GoodMorning" : "GoodAfternoon";
            return View();
        }
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        public ViewResult RsvpForm(GuestResponse guestresponse )
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guestresponse);
            }
            else
            {
                return View();//验证有错误
            }

        }
    }
}