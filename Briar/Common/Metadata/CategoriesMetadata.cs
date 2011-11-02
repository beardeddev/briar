using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Briar.Common.ModelBinders;

namespace Briar.Common.Metadata
{
    [ModelBinder(typeof(TransliterateUrlModelBinder))]
    public class CategoriesMetadata
    {
    }
}