using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20章视图.Infrastructure
{
    public class DebugDataview : IView
    {
        public void Render( ViewContext viewContext, TextWriter writer )
        {
            Write(writer, "---Routing Data---");
            foreach (string key in viewContext.RouteData.Values.Keys)
            {
                Write(writer, " key:{0},value:{1}", key, viewContext.RouteData.Values[key]);
            }
            Write(writer, "---View Data");
            foreach (string key in viewContext.ViewData.Keys)
            {
                Write(writer, " key:{0},value:{1}", key, viewContext.ViewData[key]);
            }
        }
        private void Write(TextWriter writer,string template,params object[] values )
        {
            writer.Write("<p>"+string.Format(template, values) + "<p/>");
        }
    }
}