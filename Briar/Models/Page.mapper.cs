﻿using System;
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
                return Query.EQ("State", BsonBoolean.True);
            }
        }

        public static Page FindByUrl(string url)
        {            
            BsonValue bsonUrl = new BsonString(url);

            IMongoQuery query = Query.And(Page.ActiveScope,
                    Query.EQ("Url", bsonUrl)
                );

            return Page.Collection.FindOne(query);
        }

        public static List<Page> GetMenu()
        {
            IMongoQuery query = Query.And(Page.ActiveScope,
                    Query.EQ("ShowInMenu", BsonBoolean.True)
                );

            return Page.Collection.Find(query).ToList();
        }
    }
}