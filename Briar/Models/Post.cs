using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using MongoDB.Bson;

using FluentValidation.Attributes;

using Briar.Common.Validation;
using Briar.Common.Metadata;
using Briar.Common.Data;

using Shamrock.Data.MongoExtensions;
using Shamrock.Data.MongoExtensions.Mapping;

namespace Briar.Models
{
    /// <summary>
    /// Wraps Posts table
    /// </summary>
    [Validator(typeof(PostsValidator))]
    [MetadataType(typeof(PostsMetadata))]
    [Collection("posts")]
    public partial class Post : DocumentBase<Post>
    {
        /// <summary>
        /// Wraps Id column
        /// </summary>        
        public BsonObjectId Id { get; set; }

        /// <summary>
        /// Wraps Title column
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Wraps PublishedOn column
        /// </summary>
        public DateTime PublishedOn { get; set; }

        /// <summary>
        /// Wraps TitleTransliterated column
        /// </summary>
        public string TitleTransliterated { get; set; }

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
        /// Wraps CreatedOn column
        /// </summary>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Wraps UpdatedOn column
        /// </summary>
        public DateTime UpdatedOn { get; set; }

        /// <summary>
        /// Wraps Categories relation
        /// </summary>
        private List<Category> _Categories;
        public List<Category> Categories
        {
            get { return _Categories ?? new List<Category>(); }
            set { _Categories = value; }
        }

        /// <summary>
        /// Wraps Tags relation
        /// </summary>
        private List<Tag> _Tags;
        public List<Tag> Tags
        {
            get { return _Tags ?? new List<Tag>(); }
            set { _Tags = value; }
        }
    }
}