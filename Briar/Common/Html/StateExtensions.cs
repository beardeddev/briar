using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shamrock.Web.Mvc.Html;

using Briar.Common.Resources;

namespace Briar.Common.Html
{
    public static class StateExtensions
    {
        public static MvcHtmlString StateImage(this HtmlHelper htmlHelper, bool status)
        {
            UrlHelper urlHelper = new UrlHelper(htmlHelper.ViewContext.RequestContext);

            string statusName = status.ToString();
            string imageSrc = urlHelper.Content("~/Images/Status/" + statusName + ".png");
            string imageAlt = Display.ResourceManager.GetString(statusName);

            TagBuilder tagBuilder = new TagBuilder("img");
            tagBuilder.MergeAttribute("src", imageSrc);
            tagBuilder.MergeAttribute("alt", imageAlt);
            tagBuilder.MergeAttribute("title", imageAlt);

            return tagBuilder.ToMvcHtmlString(TagRenderMode.SelfClosing);
        }
    }
}