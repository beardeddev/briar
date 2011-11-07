using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Briar.ViewModels;
using Briar.Common.Data;

using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

using Shamrock.Data.MongoExtensions.Mapping;
using Shamrock.Data.MongoExtensions;
using Shamrock.Data;

namespace Briar.Models
{
    public partial class Post : DocumentBase<Post>
    {
        public static IMongoQuery ActiveScope
        {
            get
            {
                return Query.And(Query.EQ("state", BsonBoolean.True),
                    Query.LTE("published_on", DateTime.Now)
                    );
            }
        }

        public static IMongoSortBy DefaultSortByScope
        {
            get
            {
                SortByBuilder sortBy = new SortByBuilder();
                sortBy.Descending(new string[] { "published_on" });
                return sortBy;
            }
        }

        public static PagedCollection<Post> FindPaged(IMongoQuery query, int offset, int limit)
        {
            MongoCursor<Post> pagesCursor = Post.Collection.Find(query)
                .SetSortOrder(Post.DefaultSortByScope)
                .SetSkip(offset)
                .SetLimit(limit);      
      
            return new PagedCollection<Post>
            {
                Collection = pagesCursor.ToList(),
                TotalCount = pagesCursor.Count(),
                PageIndex = offset,
                PageSize = limit
            };
        }

        public static PagedCollection<Post> FindPaged(int offset, int limit)
        {
            return FindPaged(Post.ActiveScope, offset, limit);
        }

        public static PagedCollection<Post> FindPagedByCategory(string categoryUrl, int offset, int limit)
        {

            IMongoQuery query = Query.And(Post.ActiveScope,
                    Query.EQ("categories.url", new BsonString(categoryUrl))
                );

            return FindPaged(query, offset, limit);
        }

        public static PagedCollection<Post> FindPagedByTag(string tagUrl, int offset, int limit)
        {
            IMongoQuery query = Query.And(Post.ActiveScope,
                    Query.EQ("tags.url", new BsonString(tagUrl))
                );

            return FindPaged(query, offset, limit);
        }

        public static PagedCollection<Post> FindPagedByYearMonth(int year, int month, int offset, int limit)
        {
            DateTime startDate = new DateTime(year, month, 1);
            DateTime endDate = new DateTime(year, month, DateTime.DaysInMonth(year, month));

            IMongoQuery query = Query.And(Query.EQ("state", BsonBoolean.True),
                    Query.GTE("published_on", new BsonDateTime(startDate)),
                    Query.LTE("published_on", new BsonDateTime(endDate))
                );

            return FindPaged(query, offset, limit);
        }

        public static Post FindByTitle(IMongoQuery query, string title)
        {
            return Post.Collection.FindOne(Query.And(query,
                    Query.EQ("title", new BsonString(title))
                ));
        }

        public static Post FindByTitle(string title)
        {
            return FindByTitle(Post.ActiveScope, title);
        }

        public static Post FindByTitleTransliterated(IMongoQuery query, string title)
        {
            return Post.Collection.FindOne(Query.And(query,
                    Query.EQ("title_transliterated", new BsonString(title))
                ));
        }

        public static Post FindByTitleTransliterated(string title)
        {
            return FindByTitleTransliterated(Post.ActiveScope, title);
        }

        public static List<Cloud> GetCategoriesCloud()
        {
            BsonJavaScript map = new BsonJavaScript(@"
                function () {
                    if (!this.categories) {
                        return;
                    }

                    for (index in this.categories) {
                        emit({
                            title: this.categories[index].title,
                            url: this.categories[index].url
                        }, {
                            count: 1
                        });
                    }
                }");

            BsonJavaScript reduce = new BsonJavaScript(@"
                function (key, values) {
                    var count = 0;

                    values.forEach(function (v) {
                        count += v['count'];
                    });

                    return {
                        count: count
                    };
                }");

            return Post.Collection.MapReduce(map, reduce)
                .GetResultsAs<Cloud>()
                .ToList();
        }

        public static ArchiveCollection GetArchive()
        {
            BsonJavaScript groupBy = new BsonJavaScript(@"
                function (x) {
                    return {
                        month: x.published_on.getMonth(),
                        year: x.published_on.getFullYear()
                    }
                }");

            BsonJavaScript reduce = new BsonJavaScript(@"
                function (x, y) {
                    y.count++;
                    y.year = x.published_on.getFullYear();
                    y.month = x.published_on.getMonth();
                }");

            BsonDocument initial = new BsonDocument(new Dictionary<string, object>{ 
                    { "count", 0 }, 
                    { "month", null },
                    { "year", null }
                });


            List<BsonDocument> bsonDocCollection = Post.Collection.Group(Post.ActiveScope, 
                groupBy, initial, reduce, null)
                .ToList();

            return new ArchiveCollection(bsonDocCollection);
        }
    }
}