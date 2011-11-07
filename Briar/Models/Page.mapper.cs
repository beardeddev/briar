using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

using Shamrock.Data.MongoExtensions;

using Briar.Common.Data;

namespace Briar.Models
{
    public partial class Page : DocumentBase<Page>
    {
        public static IMongoQuery ActiveScope
        {
            get
            {
                return Query.EQ("state", BsonBoolean.True);
            }
        }

        public static Page FindByUrl(IMongoQuery query, string url)
        {
            BsonValue bsonUrl = new BsonString(url);

            return Page.Collection.FindOne(Query.And(query,
                Query.EQ("url", bsonUrl))
                );
        }

        public static Page FindByUrl(string url)
        {
            return Page.FindByUrl(Page.ActiveScope, url);
        }

        public static List<Page> GetMenu()
        {
            IMongoQuery query = Query.And(Page.ActiveScope,
                    Query.EQ("show_in_menu", BsonBoolean.True)
                );

            return Page.Collection.Find(query).ToList();
        }
    }
}