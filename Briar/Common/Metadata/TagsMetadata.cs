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
    [ModelBinder(typeof(TransliterateUrlModelBinder))]
    public class TagsMetadata
    {
        /// <summary>
        /// Wraps Id column
        /// </summary>                
        [Display(Name = "Id", ResourceType = typeof(Display))]
        public ObjectId Id { get; set; }

        /// <summary>
        /// Wraps Title column
        /// </summary>
        [Display(Name = "Title", ResourceType = typeof(Display))]
        public string Title { get; set; }

        /// <summary>
        /// Wraps Url column
        /// </summary>
        [Display(Name = "Url", ResourceType = typeof(Display))]
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Display(Name = "ObjectId", ResourceType = typeof(Display))]
        public string ObjectId
        {
            get
            {
                return this.Id.ToString();
            }
        }
    }
}