using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Briar.Models;
using Briar.Common.Controllers;

using Shamrock.Data;

namespace Briar.Controllers
{
    public class CategoriesController : FrontendController
    {
        public ActionResult Details(string url, int? page)
        {
            PagedCollection<Post> model = Post.FindPagedByCategory(url, page ?? 0, 25); 
            return View("Index", model);
        }
    }
}
