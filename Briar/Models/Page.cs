using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using MongoDB.Bson;

using FluentValidation.Attributes;

using Shamrock.Data.MongoExtensions;
using Shamrock.Data.MongoExtensions.Mapping;

using Briar.Common.Validation;
using Briar.Common.Metadata;
using Briar.Common.Data;

namespace Briar.Models
{
    /// <summary>
    /// Wraps Pages table
    /// </summary>
    [Validator(typeof(PagesValidator))]
    [MetadataType(typeof(PagesMetadata))]
    [Collection("pages")]
    public partial class Page : DocumentBase<Page>
    {
        /// <summary>
        /// Wraps Id column
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Wraps LayoutId column
        /// </summary>
        public string LayoutPath { get; set; }

        /// <summary>
        /// Wraps Url column
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Wraps Title column
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Wraps Keywords column
        /// </summary>
        public string Keywords { get; set; }

        /// <summary>
        /// Wraps Description column
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Wraps Body column
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Wraps ImageSource column
        /// </summary>
        public string ImageSource { get; set; }

        /// <summary>
        /// Wraps State column
        /// </summary>
        public bool State { get; set; }

        /// <summary>
        /// Wraps ShowInMenu column
        /// </summary>
        public bool ShowInMenu { get; set; }

        /// <summary>
        /// Wraps CreatedOn column
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Wraps UpdatedOn column
        /// </summary>
        
        public DateTime UpdatedOn { get; set; }

    }
}