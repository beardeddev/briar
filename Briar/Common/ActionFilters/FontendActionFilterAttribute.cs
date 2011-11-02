using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Briar.Models;

namespace Briar.Common.ActionFilters
{
    public class FontendActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            filterContext.Controller.ViewBag.CategoriesCloud = Post.GetCategoriesCloud();
            filterContext.Controller.ViewBag.Archive = Post.GetArchive();
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
            
            Page page = Page.FindByUrl(filterContext.HttpContext.Request.Url.AbsolutePath);
            if (page != null)
            {
                filterContext.Controller.ViewBag.Title = page.Title;
                filterContext.Controller.ViewBag.Keywords = page.Keywords;
                filterContext.Controller.ViewBag.Description = page.Description;
            }
        }
    }
}