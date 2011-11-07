using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using Briar.Common.ModelBinders;
using Briar.Common.Metadata;
using Briar.Common.Generalization;

using Shamrock.Data.MongoExtensions.Mapping;

namespace Briar.Models
{
    [MetadataType(typeof(TagsMetadata))]
    public partial class Tag : ITransliterateUrl
    {
        /// <summary>
        /// Wraps Id column
        /// </summary>
        public ObjectId Id { get; set; }

        /// <summary>
        /// Wraps Title column
        /// </summary>
        [BsonElement("title")]
        public string Title { get; set; }

        /// <summary>
        /// Wraps Url column
        /// </summary>
        [BsonElement("url")]
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [BsonIgnore]
        public string ObjectId
        {
            get
            {
                return this.Id.ToString();
            }
        }
    }
}