using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shamrock.Core;

using Briar.Models;

namespace Briar.Common.ModelBinders
{
    public class PostsModelBinder : DefaultDocumentModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            Post post = (Post)base.BindModel(controllerContext, bindingContext);
            if (string.IsNullOrEmpty(post.TitleTransliterated))
            {
                post.TitleTransliterated = post.Title.Trim().Transliterate();
            }
            return post;
        }
    }
}