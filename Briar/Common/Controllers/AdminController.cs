using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shamrock.Web.Mvc.MongoSupport;
using Shamrock.Data.MongoExtensions;

using Briar.Common.ActionFilters;

namespace Briar.Common.Controllers
{
    [AdminMenuActionFilter]
    public class AdminController<T> : ResourceController<T>
        where T : Document<T>, new()
    {
        public override ActionResult Create(T model)
        {
            if (ModelState.IsValid)
            {
                return base.Create(model);
            }
            else
            {
                return View(model);
            }
        }

        public override ActionResult Edit(MongoDB.Bson.ObjectId id, T model)
        {
            if (ModelState.IsValid)
            {
                return base.Edit(id, model);
            }
            else
            {
                return View(model);
            }
        }
    }
}
