using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

using Briar.Common.ModelBinders;
using Briar.Common.Resources;

using MongoDB.Bson;

namespace Briar.Common.Metadata
{
    public class PagesMetadata
    {        
        /// <summary>
        /// Wraps Id column
        /// </summary>
        [Display(Name = "Id", ResourceType = typeof(Display))]
        public ObjectId Id { get; set; }

        /// <summary>
        /// Wraps LayoutId column
        /// </summary>
        [Display(Name = "LayoutPath", ResourceType = typeof(Display))]
        public string LayoutPath { get; set; }

        /// <summary>
        /// Wraps Url column
        /// </summary>
        [Display(Name = "Url", ResourceType = typeof(Display))]
        public string Url { get; set; }

        /// <summary>
        /// Wraps Title column
        /// </summary>
        [Display(Name = "Title", ResourceType = typeof(Display))]
        public string Title { get; set; }

        /// <summary>
        /// Wraps Keywords column
        /// </summary>
        [Display(Name = "Keywords", ResourceType = typeof(Display))]
        public string Keywords { get; set; }

        /// <summary>
        /// Wraps Description column
        /// </summary>
        [Display(Name = "Description", ResourceType = typeof(Display))]
        public string Description { get; set; }

        /// <summary>
        /// Wraps Body column
        /// </summary>
        [Display(Name = "Body", ResourceType = typeof(Display))]
        public string Body { get; set; }

        /// <summary>
        /// Wraps ImageSource column
        /// </summary>
        [Display(Name = "ImageSource", ResourceType = typeof(Display))]
        public string ImageSource { get; set; }

        /// <summary>
        /// Wraps State column
        /// </summary>
        [Display(Name = "State", ResourceType = typeof(Display))]
        public bool State { get; set; }

        /// <summary>
        /// Wraps ShowInMenu column
        /// </summary>
        [Display(Name = "ShowInMenu", ResourceType = typeof(Display))]
        public bool ShowInMenu { get; set; }

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