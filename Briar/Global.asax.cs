using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using MongoDB.Bson;

using Briar.Common.ModelBinders;
using Briar.Common.Resources;

using Shamrock.Web.Mvc.MongoSupport.ModelBinders;
using Shamrock.Web.Mvc.ActionFilters;

using FluentValidation;
using FluentValidation.Mvc;
using Shamrock.Data.MongoExtensions;
using Briar.Models;

namespace Briar
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RequestTimeActionFilterAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("Images/{*pathInfo}");
            routes.IgnoreRoute("Scripts/{*pathInfo}");
            routes.IgnoreRoute("Content/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");

            routes.MapRoute(
                "Root", // Route name
                "", // URL with parameters
                new { controller = "Posts", action = "Index" }, // Parameter defaults
                new string[] { "Briar.Controllers" }
            );

            routes.MapRoute(
                "Post", // Route name
                "posts/{title}", // URL with parameters
                new { controller = "Posts", action = "Details" }, // Parameter defaults
                new string[] { "Briar.Controllers" }
            );

            routes.MapRoute(
                "CategoriesAndTags", // Route name
                "{controller}/{url}", // URL with parameters
                new { controller = "Categories", action = "Details" }, // Parameter defaults
                new string[] { "Briar.Controllers" }
            );

            routes.MapRoute(
                "Sitemap", // Route name
                "sitemap.xml", // URL with parameters
                new { controller = "Utility", action = "SiteMap" }, // Parameter defaults
                new string[] { "Briar.Controllers" }
            );

            routes.MapRoute(
                "RSS", // Route name
                "rss", // URL with parameters
                new { controller = "Utility", action = "RSS" }, // Parameter defaults
                new string[] { "Briar.Controllers" }
            );

            routes.MapRoute(
                "Archive", // Route name
                "archive/{year}/{month}", // URL with parameters
                new { controller = "Archive", action = "Details" }, // Parameter defaults
                new { year = "\\d+", month = "\\d+" },
                new string[] { "Briar.Controllers" }
            );

            routes.MapRoute(
                "Page", // Route name
                "{*url}", // URL with parameters
                new { controller = "Pages", action = "Details", url = UrlParameter.Optional }, // Parameter defaults
                new string[] { "Briar.Controllers" }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            FluentValidationModelValidatorProvider.Configure();
            ValidatorOptions.ResourceProviderType = typeof(ValidationMessages);

            ModelBinders.Binders.Add(typeof(BsonObjectId), new BsonObjectIdBinder());
            ModelBinders.Binders.Add(typeof(ObjectId), new ObjectIdBinder());

            SetUpMongo();
        }

        protected void SetUpMongo()
        {
            Mongo connection = new Mongo();
            
            if (!connection.Database.CollectionExists("pages"))
            {
                connection.Database.CreateCollection("pages");
            }

            if (!connection.Database.CollectionExists("posts"))
            {
                connection.Database.CreateCollection("posts");
            }

            if (!connection.Database.CollectionExists("users"))
            {
                connection.Database.CreateCollection("users");
            }

        }
    }
}