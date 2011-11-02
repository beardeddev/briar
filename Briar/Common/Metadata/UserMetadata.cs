using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using Briar.Common.Resources;

namespace Briar.Common.Metadata
{
    public class UserMetadata
    {
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType=typeof(Display))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "PasswordConfirmation", ResourceType = typeof(Display))]
        public string PasswordConfirmation { get; set; }

        [Display(Name = "UserName", ResourceType = typeof(Display))]
        public string UserName { get; set; }

        [Display(Name = "Email", ResourceType = typeof(Display))]
        public string Email { get; set; }
    }
}