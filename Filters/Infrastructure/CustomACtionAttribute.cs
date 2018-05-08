using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Filters.Infrastructure
{
    public class CustomACtionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted( ActionExecutedContext filterContext )
        {
            
        }

        public void OnActionExecuting( ActionExecutingContext filterContext )
        {
            if (filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }
    }
}