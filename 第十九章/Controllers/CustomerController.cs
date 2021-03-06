﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 第十九章.Models;

namespace 第十九章.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View("Customer", new Result { ControllerName = "Product", ActionName = "Index" });
        }
        public ViewResult List()
        {
            return View("Customer", new Result
            {
                ControllerName = "Product",
                ActionName = "List"
            });
        }
    }
}