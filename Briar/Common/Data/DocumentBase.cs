using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Shamrock.Data.MongoExtensions;

using Briar.Common.ModelBinders;

namespace Briar.Common.Data
{
    [ModelBinder(typeof(DefaultDocumentModelBinder))]
    public class DocumentBase<T> : Document<T>
        where T : DocumentBase<T>, new()
    {
        public DocumentBase()
        {
            this.DisableValidation = true;
        }
    }
}