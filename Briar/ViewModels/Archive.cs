using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Briar.ViewModels
{
    public class Archive
    {
        public Archive(BsonDocument document)
        {
            this.Year = (int)document.GetValue("year").AsDouble;
            this.Month = ((int)document.GetValue("month").AsDouble) + 1;
            this.Count = document.GetValue("count").AsDouble;
        }

        [BsonElement("year")]
        public int Year { get; set; }

        [BsonElement("month")]
        public int Month { get; set; }

        [BsonElement("count")]
        public Double Count { get; set; }

        [BsonIgnore]
        public string Title
        {
            get
            {
                return string.Format("{0:MMMM yyyy} (1)", new DateTime(this.Year, this.Month, 1), this.Count);
            }
        }

        public object ToUrlParams()
        {
            return new { @month = this.Month, @year = this.Year };
        }
    }

    public class ArchiveCollection : List<Archive>
    {
        public ArchiveCollection(List<BsonDocument> archives)
        {
            foreach (BsonDocument doc in archives)
            {
                Archive arc = new Archive(doc);
                this.Add(arc);
            }
        }
    }
}