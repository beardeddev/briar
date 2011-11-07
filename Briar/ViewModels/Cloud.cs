using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Briar.Models;

using MongoDB.Bson.Serialization.Attributes;

namespace Briar.ViewModels
{
    public class CloudKey
    {
        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("url")]
        public string Url { get; set; }
    }

    public class CloudValue
    {
        [BsonElement("count")]
        public float Count { get; set; }
    }

    public class Cloud
    {
        [BsonElement("id")]
        public CloudKey Id { get; set; }

        [BsonElement("value")]
        public CloudValue Value { get; set; }

        [BsonIgnore]
        public string Title
        {
            get
            {
                return string.Format("{0} ({1})", this.Id.Title, this.Value.Count);
            }
        }

        public object ToUrlParams()
        {
            return new { @url = this.Id.Url };
        }
    }
}