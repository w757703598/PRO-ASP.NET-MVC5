using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _21章辅助器方法.Infrastructure
{
    public static class CustomHelper
    {
        public static MvcHtmlString ListArrayItems(this HtmlHelper html,string[] list )
        {
            TagBuilder tag = new TagBuilder("ul");
            foreach (string  str in list)
            {
                TagBuilder itemtag = new TagBuilder("li");
                itemtag.SetInnerText(str);
                tag.InnerHtml += itemtag.ToString();
            }
            return new MvcHtmlString(tag.ToString());
        }
        public static MvcHtmlString DisplayMessage(this HtmlHelper html,string msg )
        {
            string result = string.Format("This is the message:<p>{0}</p>", msg);
            return new MvcHtmlString(result);
        }
    }
}