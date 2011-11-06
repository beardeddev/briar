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

        /// <summary>
        /// Wraps Keywords column
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Keywords { get; set; }

        /// <summary>
        /// Wraps Description column
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// Wraps PublishedOn column
        /// </summary>
        [DataType(DataType.DateTime)]
        public DateTime PublishedOn { get; set; }

        /// <summary>
        /// Wraps Body column
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}