using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Briar.Common.Controllers;
using Briar.Models;

using MongoDB.Bson;

namespace Briar.Areas.Admin.Controllers
{
    public class PostsController : AdminController<Post>
    {
    }
}
