using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Briar.Common.Data;

using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver;

using Shamrock.Security;

namespace Briar.Models
{
    public partial class User : DocumentBase<User>
    {
        public static IMongoQuery ActiveScope
        {
            get
            {
                return Query.EQ("state", BsonBoolean.True);
            }
        }

        public static User FindByUserName(string userName)
        {
            IMongoQuery query = Query.EQ("user_name", userName);
            return User.Collection.FindOne(query);
        }

        public static User FindByEmail(string email)
        {
            IMongoQuery query = Query.EQ("email", email);
            return User.Collection.FindOne(query);
        }

        public override void OnSave()
        {
            if (!string.IsNullOrEmpty(this.Password))
            {
                Password pass = new Password(this.Password);
                this.PasswordHash = pass.Hash;
                this.PasswordSalt = pass.Salt;                
            }

            if (this.IsNew)
            {
                this.PersistenceToken = Guid.NewGuid().ToString();
                this.LoginCount = 0;
            }

            base.OnSave();
        }

        public bool Validate(string password)
        {
            Password pwd = new Password(this.PasswordSalt, this.PasswordHash);
            return pwd.Verify(password);
        }
    }
}