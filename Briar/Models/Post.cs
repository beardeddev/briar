using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using FluentValidation.Attributes;

using Briar.Common.Validation;
using Briar.Common.Metadata;
using Briar.Common.Data;

using Shamrock.Data.MongoExtensions;
using Shamrock.Data.MongoExtensions.Mapping;
using Shamrock.Data.Mapping;

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
        [BsonElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Wraps PublishedOn column
        /// </summary>
        [BsonElement("published_on")]
        public DateTime PublishedOn { get; set; }

        /// <summary>
        /// Wraps TitleTransliterated column
        /// </summary>
        [BsonElement("title_transliterated")]
        public string TitleTransliterated { get; set; }

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
        [UIHint("Body")]
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
        /// Wraps CreatedOn column
        /// </summary>
        [BsonElement("created_on")]
        [TimeStamp(AutoAddNow = true, AutoUpdateNow = false)]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Wraps UpdatedOn column
        /// </summary>
        [BsonElement("updated_on")]
        [TimeStamp(AutoAddNow = true, AutoUpdateNow = true)]
        public DateTime UpdatedOn { get; set; }
                
        private List<Category> _Categories;
        /// <summary>
        /// Wraps Categories relation
        /// </summary>        
        [BsonElement("categories")]
        public List<Category> Categories
        {
            get { return _Categories ?? new List<Category>(); }
            set { _Categories = value; }
        }
                
        private List<Tag> _Tags;
        /// <summary>
        /// Wraps Tags relation
        /// </summary>
        [BsonElement("tags")]
        public List<Tag> Tags
        {
            get { return _Tags ?? new List<Tag>(); }
            set { _Tags = value; }
        }
    }
}