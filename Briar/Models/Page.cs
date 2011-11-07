using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using FluentValidation.Attributes;

using Shamrock.Data.MongoExtensions;
using Shamrock.Data.MongoExtensions.Mapping;
using Shamrock.Data.Mapping;

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
        [BsonElement("layout_path")]
        public string LayoutPath { get; set; }

        /// <summary>
        /// Wraps Url column
        /// </summary>
        [BsonElement("url")]
        public string Url { get; set; }

        /// <summary>
        /// Wraps Title column
        /// </summary>
        [BsonElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Wraps Keywords column
        /// </summary>
        [BsonElement("keywords")]
        public string Keywords { get; set; }

        /// <summary>
        /// Wraps Description column
        /// </summary>
        [BsonElement("description")]
        public string Description { get; set; }

        /// <summary>
        /// Wraps Body column
        /// </summary>
        [BsonElement("body")]
        public string Body { get; set; }

        /// <summary>
        /// Wraps ImageSource column
        /// </summary>
        [BsonElement("image_source")]
        public string ImageSource { get; set; }

        /// <summary>
        /// Wraps State column
        /// </summary>
        [BsonElement("state")]
        public bool State { get; set; }

        /// <summary>
        /// Wraps ShowInMenu column
        /// </summary>
        [BsonElement("show_in_menu")]
        public bool ShowInMenu { get; set; }

        /// <summary>
        /// Wraps CreatedOn column
        /// </summary>
        [BsonElement("created_on")]
        [TimeStamp(AutoAddNow = true, AutoUpdateNow = false)]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Wraps UpdatedOn column
        /// </summary>
        [BsonElement("updated_on")]
        [TimeStamp(AutoAddNow=true, AutoUpdateNow=true)]
        public DateTime UpdatedOn { get; set; }

    }
}