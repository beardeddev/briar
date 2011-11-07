using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using Briar.Models;
using Briar.Common.ModelBinders;
using Briar.Common.Resources;

namespace Briar.Common.Metadata
{
    [ModelBinder(typeof(PostsModelBinder))]    
    public class PostsMetadata
    {
        /// <summary>
        /// Wraps Categories relation
        /// </summary>
        [UIHint("Categories")]
        [Display(Name = "Categories", ResourceType = typeof(Display))]
        public List<Category> Categories { get; set; }

        /// <summary>
        /// Wraps Categories relation
        /// </summary>
        [UIHint("Tags")]
        [Display(Name = "Tags", ResourceType = typeof(Display))]
        public List<Tag> Tags { get; set; }

        /// <summary>
        /// Wraps Keywords column
        /// </summary>
        [Display(Name = "Keywords", ResourceType = typeof(Display))]
        [DataType(DataType.MultilineText)]
        public string Keywords { get; set; }

        /// <summary>
        /// Wraps Description column
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description", ResourceType = typeof(Display))]
        public string Description { get; set; }

        /// <summary>
        /// Wraps PublishedOn column
        /// </summary>
        [DataType(DataType.DateTime)]
        [Display(Name = "PublishedOn", ResourceType = typeof(Display))]
        public DateTime PublishedOn { get; set; }

        /// <summary>
        /// Wraps Body column
        /// </summary>
        [DataType(DataType.MultilineText)]
        [Display(Name = "Body", ResourceType = typeof(Display))]
        public string Body { get; set; }

        /// <summary>
        /// Wraps State column
        /// </summary>
        [Display(Name = "State", ResourceType = typeof(Display))]
        public bool State { get; set; }

        /// <summary>
        /// Wraps CreatedOn column
        /// </summary>
        [Display(Name = "CreatedOn", ResourceType = typeof(Display))]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Wraps UpdatedOn column
        /// </summary>
        [Display(Name = "UpdatedOn", ResourceType = typeof(Display))]
        public DateTime UpdatedOn { get; set; }
    }
}