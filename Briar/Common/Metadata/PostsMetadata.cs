using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Briar.Models;
using Briar.Common.ModelBinders;

namespace Briar.Common.Metadata
{
    [ModelBinder(typeof(PostsModelBinder))]    
    public class PostsMetadata
    {
        /// <summary>
        /// Wraps Categories relation
        /// </summary>
        [UIHint("Categories")]
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Wraps Categories relation
        /// </summary>
        [UIHint("Tags")]
        public List<Tag> Tags { get; set; }
    }
}