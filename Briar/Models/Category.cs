﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MongoDB.Bson;

using Briar.Common.ModelBinders;
using Briar.Common.Metadata;
using Briar.Common.Generalization;

namespace Briar.Models
{
    [MetadataType(typeof(CategoriesMetadata))]
    public partial class Category : ITransliterateUrl
    {
        /// <summary>
        /// Wraps Id column
        /// </summary>                
        public ObjectId Id { get; set; }

        /// <summary>
        /// Wraps Title column
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Wraps Url column
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ObjectId
        {
            get
            {
                return this.Id.ToString();
            }
        }
    }
}