﻿using SportStore.WebUI.Infrastructure.Abstract;
using SportStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authPorvider;
        public AccountController(IAuthProvider auth )
        {
            authPorvider = auth;
        }
        public ViewResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model,string returnUrl )
        {
            if (ModelState.IsValid)
            {
                if (authPorvider.Authenticate(model.UserName, model.Password))
                {
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}