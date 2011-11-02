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
    public class PostsController : FrontendController
    {
        public ActionResult Index(int? page)
        {
            PagedCollection<Post> model = Post.FindPaged(page ?? 0, 25);
            return View(model);
        }

        public ActionResult Details(string title)
        {
            Post post = Post.FindByTitle(title);
            return ObjectOr404(post);
        }

    }
}
