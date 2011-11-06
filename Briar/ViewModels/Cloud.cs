using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Briar.Models;

namespace Briar.ViewModels
{
    public class CloudKey
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }

    public class CloudValue
    {
        public float count { get; set; }
    }

    public class Cloud
    {
        public CloudKey _id { get; set; }
        public CloudValue value { get; set; }

        public string Title
        {
            get
            {
                return string.Format("{0} ({1})", this._id.Title, this.value.count);
            }
        }

        public object ToUrlParams()
        {
            return new { @url = this._id.Url };
        }
    }
}