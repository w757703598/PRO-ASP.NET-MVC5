﻿using SportStore.Domain.Entities;
using SportStore.WebUI.Infrastructure.Binders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SportStore.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //使用CartModelBinder类创建Cart实例
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
      
        }
    }
}
