using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Briar.Common.Controllers;
using Briar.Models;

using Shamrock.Data;

namespace Briar.Controllers
{
    public class ArchiveController : FrontendController
    {
        public ActionResult Details(int year, int month, int? page)
        {
            PagedCollection<Post> model = Post.FindPagedByYearMonth(year, month, page ?? 0, 25);
            return View("Index", model);
        }
    }
}
