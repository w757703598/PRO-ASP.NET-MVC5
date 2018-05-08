using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20章视图.Infrastructure
{
    public class CustomLocationViewEngine:RazorViewEngine
    {
        public CustomLocationViewEngine()
        {
            ViewLocationFormats = new string[] { "~/Views/{1}/{0}.cshtml", "~/Views/Common/{0}.cshtml" };
        }
    }
}