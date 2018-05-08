using _21章辅助器方法.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _21章辅助器方法.Controllers
{
    public class PeopleController : Controller
    {
        private Person[] personData =
        {
            new Person {FirstName="admin" ,LastName="freeman" ,Role=Role.Admin },
            new Person {FirstName="Jonh" ,LastName="Smith" ,Role=Role.User },
            new Person {FirstName="Anne" ,LastName="Jones" ,Role=Role.Guest },
            new Person {FirstName="Jacqui" ,LastName="Griffyh" ,Role=Role.User }
        };
        // GET: People
        public ActionResult Index()
        {
            return View();
        }
        private IEnumerable<Person> GetData(string selectedRole )
        {
            IEnumerable<Person> data = personData;
            if (selectedRole != "All")
            {
                Role selected = (Role)Enum.Parse(typeof(Role), selectedRole);
                data = personData.Where(p => p.Role == selected);
            }
            return data;
        }
        public JsonResult GetPeopleDataJson(string selectedRole = "All" )
        {
            IEnumerable<Person> data = GetData(selectedRole);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPeople( string selecterRole = "All" )
        {
            return View((object) selecterRole);
        }
        public PartialViewResult GetPeopleData(string selecterRole="All" )
        {

            return PartialView(GetData(selecterRole));
        }
    }
}