using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using Shamrock.Data.MongoExtensions.Mapping;
using Shamrock.Data.Mapping;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using FluentValidation.Attributes;

using Briar.Common.Data;
using Briar.Common.Validation;
using Briar.Common.Metadata;

namespace Briar.Models
{
    [Validator(typeof(UserValidator))]
    [MetadataType(typeof(UserMetadata))]
    [Collection("users")]
    public partial class User : DocumentBase<User>
    {
        /// <summary>
        /// Wraps Id column
        /// </summary>        
        public new BsonObjectId Id { get; set; }

        #region ignored properties
        [BsonIgnore]
        public string Password { get; set; }

        [BsonIgnore]
        public string PasswordConfirmation { get; set; }
        #endregion

        #region mapped properties
        [BsonElement("user_name")]
        public string UserName { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password_hash")]
        public string PasswordHash { get; set; }

        [BsonElement("password_salt")]
        public string PasswordSalt { get; set; }

        [BsonElement("persistence_token")]
        public string PersistenceToken { get; set; }

        [BsonElement("login_count")]
        public long LoginCount { get; set; }

        [BsonElement("last_request_date")]
        public DateTime? LastRequestDate { get; set; }

        [BsonElement("last_login_date")]
        public DateTime? LastLoginDate { get; set; }

        [BsonElement("current_login_date")]
        public DateTime? CurrentLoginDate { get; set; }

        [BsonElement("state")]
        public bool State { get; set; }

        /// <summary>
        /// Wraps CreatedOn column
        /// </summary>
        [BsonElement("created_on")]
        [TimeStamp(AutoAddNow=true, AutoUpdateNow=false)]
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Wraps UpdatedOn column
        /// </summary>
        [BsonElement("updated_on")]
        [TimeStamp(AutoAddNow = true, AutoUpdateNow = true)]
        public DateTime UpdatedOn { get; set; }
        #endregion
    }
}