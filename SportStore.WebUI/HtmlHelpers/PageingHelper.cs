﻿using SportStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SportStore.WebUI.HtmlHelpers
{
    public static  class PageingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,PagingInfo pageinginfo,Func<int,string > pageUrl )
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= pageinginfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pageinginfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                sb.Append(tag.ToString());
            }
            return MvcHtmlString.Create(sb.ToString());
        }
    }
}