using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Briar.Models;
using Briar.Common.Resources;

using Shamrock.Web.Mvc.Components.Navigation;

namespace Briar.Common.ActionFilters
{
    public class MainMenuActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            List<Page> pages = Page.GetMenu();

            Menu mainMenu = new Menu(Display.MainMenu, filterContext.RequestContext.RouteData.Values);
            foreach (Page p in pages)
            {
                MenuItem item = new MenuItem(mainMenu, p.Title, p.Url);
                mainMenu.Items.Add(item);
            }

            filterContext.Controller.ViewBag.MainMenu = mainMenu;
        }
    }
}