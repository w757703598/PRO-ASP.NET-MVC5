using Filters.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Controllers
{
    public class IndexController : Controller
    {
        [CustomAuth(true)]
        [Authorize(Users ="admin")]
        // GET: Index
        public string  Index()
        {
            return "This is the Index action on the Homr controller";
        }
        [GoogleAuth]
        [Authorize(Users = "wql@google.com")]
        public string List()
        {
            return "This is the List action on the Homr controller";
        }

        //[RangeException]
        [HandleError(ExceptionType =typeof(ArgumentOutOfRangeException),View ="RangeError")]
        public string RangeTest(int id )
        {
            if (id > 100)
            {
                return string.Format("The id value is :{0}", id);
            }
            else
            {
                throw new ArgumentOutOfRangeException("id", id, "");
            }
        }
        
        //[CustomACtion]
        [ProfileResult]
        public string ActionFilterTest()
        {
            return "This is the Filter action";
        }
    }
}