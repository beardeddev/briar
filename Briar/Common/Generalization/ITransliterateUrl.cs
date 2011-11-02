using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MongoDB.Bson;

namespace Briar.Common.Generalization
{
    public interface ITransliterateUrl
    {
        ObjectId Id { get; set; }
        string Title { get; set; }
        string Url { get; set; }
    }
}
