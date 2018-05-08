using _20章视图.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _20章视图
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ViewEngines.Engines.Clear();//只希望试用 自定义视图引擎
            ViewEngines.Engines.Add(new DebugDataViewEngine());

            ViewEngines.Engines.Clear();//只希望试用 自定义视图引擎
            ViewEngines.Engines.Add(new CustomLocationViewEngine());
        }
    }
}
