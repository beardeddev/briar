using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shamrock.Data;

using MongoDB.Bson;

namespace Briar.Common.ModelBinders
{
    public class DefaultDocumentModelBinder : DefaultModelBinder
    {
        /*
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            IEntity<ObjectId> model = (IEntity<ObjectId>)base.BindModel(controllerContext, bindingContext);

            object modelId = controllerContext.RequestContext.RouteData.Values["id"];            
            if(modelId != null)
            {
                
                model.Id = new ObjectId(modelId.ToString());
            }

            return model;
        }
         * */
    }
}