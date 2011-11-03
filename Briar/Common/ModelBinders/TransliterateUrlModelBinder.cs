using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Briar.Common.Generalization;

using Shamrock.Core;

using MongoDB.Bson;

namespace Briar.Common.ModelBinders
{
    public class TransliterateUrlModelBinder : DefaultModelBinder
    {
        public override object BindModel(System.Web.Mvc.ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            ITransliterateUrl model = (ITransliterateUrl)base.BindModel(controllerContext, bindingContext);

            if (model.Id == ObjectId.Empty)
            {
                model.Id = ObjectId.GenerateNewId();
            }

            if (model.Url.IsNullOrEmpty())
            {
                model.Url = model.Title.Transliterate();
            }

            return model;
        }
    }
}