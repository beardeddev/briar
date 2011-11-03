using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shamrock.Data;
using Shamrock.Web.Mvc.ModelBinders;

using MongoDB.Bson;

namespace Briar.Common.ModelBinders
{
    public class DefaultDocumentModelBinder : EntityModelBinder
    {
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            IEntity<ObjectId> model = (IEntity<ObjectId>)base.CreateModel(controllerContext, bindingContext, modelType);
            if (controllerContext.RequestContext.RouteData.Values["id"] != null)
            {
                model.Id = new ObjectId(controllerContext.RequestContext.RouteData.Values["id"].ToString());
            }
            return model;
        }
    }
}