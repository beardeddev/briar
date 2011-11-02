using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

using Briar.Models;
using Briar.Common.Configuration;

namespace Briar.Controllers
{
    public class UtilityController : Controller
    {
        public ContentResult SiteMap()
        {
            List<Page> pages = Page.Collection.Find(Page.ActiveScope).ToList();
            List<Post> posts = Post.Collection.Find(Post.ActiveScope)
                .SetSortOrder(Post.DefaultSortByScope)
                .ToList();

            var sitemap = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                new XElement(AppSettings.SiteMapNamespace + "urlset",
                        from p in pages
                        select
                          new XElement(AppSettings.SiteMapNamespace + "url",
                            new XElement(AppSettings.SiteMapNamespace + "loc", string.Format(AppSettings.PageUrlFormat, Request.Url.Host, p.Url)),
                                new XElement("lastmod", String.Format("{0:yyyy-MM-dd}", p.UpdatedOn)) 
                                ),
                            new XElement("changefreq", "monthly"),
                            new XElement("priority", "0.5"),
                        from p in posts
                        select
                            new XElement(AppSettings.SiteMapNamespace + "url",
                            new XElement(AppSettings.SiteMapNamespace + "loc", string.Format(AppSettings.PostUrlFormat, Request.Url.Host, p.TitleTransliterated)),
                                new XElement("lastmod", String.Format("{0:yyyy-MM-dd}", p.UpdatedOn)) 
                                ),
                            new XElement("changefreq", "monthly"),
                            new XElement("priority", "0.5")
                        )                                                              
                );

            return Content(sitemap.ToString(), "text/xml");
        }

        public ContentResult RSS()
        {
            List<Post> posts = Post.Collection.Find(Post.ActiveScope)
                .SetSortOrder(Post.DefaultSortByScope)
                .ToList();

            var rss = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("rss",
                  new XAttribute("version", "2.0"),
                        new XElement("channel",
                          new XElement("title", AppSettings.RSSTitle),
                          new XElement("link", AppSettings.RSSLink),
                          new XElement("description", AppSettings.RSSDescription),
                          new XElement("copyright", AppSettings.RSSCopyright),
                        from p in posts
                        select
                        new XElement("item",
                              new XElement("title", p.Title),
                              new XElement("description", p.Description),
                              new XElement("link", String.Format(AppSettings.PostUrlFormat, Request.Url.Host, p.TitleTransliterated)),
                              new XElement("pubDate", p.PublishedOn.ToString("R")),
                              new XElement("guid", String.Format(AppSettings.PostUrlFormat, Request.Url.Host, p.TitleTransliterated))
                              )
                          )
                     )
                );

            return Content(rss.ToString(), "text/xml");
        }
    }
}
