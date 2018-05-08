﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportStore.Domain.Abstract;

namespace SportStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductsRepository repository;
        public NavController(IProductsRepository repo )
        {
            repository = repo;
        }
        
        // GET: Nav
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult Menu(string category=null/*,bool horizontotalLayout=false*/)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);
            //string viewName = horizontotalLayout ? "MenuHorizontal" : "Menu";
            //return PartialView(viewName,categories);
            return PartialView("FlexMenu", categories);
        }
    }
}