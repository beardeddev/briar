using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shamrock.Web.Mvc.Components.Navigation;

using Briar.Common.Resources;

namespace Briar.Common.ActionFilters
{
    public class AdminMenuActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            Menu mainMenu = new Menu(Display.MainMenu, filterContext.RequestContext.RouteData.Values);

            mainMenu.Items = new List<MenuItem>()
            {
                new MenuItem(mainMenu, Display.Pages, "Index", "Pages"),
                new MenuItem(mainMenu, Display.Posts, "Index", "Posts"),
                new MenuItem(mainMenu, Display.Users, "Index", "Users"),
            };

            filterContext.Controller.ViewBag.MainMenu = mainMenu;
        }
    }
}