using System;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

using Briar.Common;
using Briar.Models;

using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

using Briar.Common.Controllers;

namespace Briar.Areas.Admin.Controllers
{
    public class PagesController : AdminController<Page>
    {

    }
}
