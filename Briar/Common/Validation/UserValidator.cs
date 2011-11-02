using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FluentValidation;
using Briar.Models;
using Briar.Common.Resources;

namespace Briar.Common.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.Email).NotNull().EmailAddress();

            RuleFor(x => x.UserName).Must(beUniqueUserName)
                .When(x => x.IsNew)
                .WithLocalizedMessage(() => ValidationMessages.NotUniqueUserNameError);

            RuleFor(x => x.Email).Must(beUniqueEmail)
                .When(x => x.IsNew)
                .WithLocalizedMessage(() => ValidationMessages.NotUniqueUserEmailError);

            RuleFor(x => x.Password).NotNull().When(x => x.IsNew);
            RuleFor(x => x.PasswordConfirmation).NotNull().When(x => x.IsNew)
                .Equal(x => x.Password).When(x => !string.IsNullOrEmpty(x.Password));
        }

        private bool beUniqueUserName(string userName)
        {
            return User.FindByUserName(userName) == null;
        }

        private bool beUniqueEmail(string email)
        {
            return User.FindByEmail(email) == null;
        }

    }
}