using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Configuration;

namespace Briar.Common.Configuration
{
    public static class AppSettings
    {
        public static readonly XNamespace SiteMapNamespace = ConfigurationManager.AppSettings["sm:NameSpace"];
        public static readonly string PostUrlFormat = ConfigurationManager.AppSettings["sm:PostUrlFormat"];
        public static readonly string PageUrlFormat = ConfigurationManager.AppSettings["sm:PageUrlFormat"];
        public static readonly string RSSTitle = ConfigurationManager.AppSettings["rss:Title"];
        public static readonly string RSSLink = ConfigurationManager.AppSettings["rss:Link"];
        public static readonly string RSSDescription = ConfigurationManager.AppSettings["rss:Description"];
        public static readonly string RSSCopyright = ConfigurationManager.AppSettings["rss:Copyright"];
    }
}