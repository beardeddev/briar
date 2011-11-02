using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Briar.Models;
using Briar.Common.Controllers;

namespace Briar.Controllers
{
    public class PagesController : FrontendController
    {
        public ActionResult Details(string url)
        {
            Page page = Page.FindByUrl(Request.Url.AbsolutePath);
            return ObjectOr404(page);
        }

    }
}
