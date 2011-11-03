using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FluentValidation;

using Briar.Models;
using Briar.Common.Resources;

using MongoDB.Driver.Builders;

namespace Briar.Common.Validation
{
    public class PostsValidator : AbstractValidator<Post>
    {
        public PostsValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Length(0, 128)
                .Must(beUniqueTitle).When(x => x.IsNew)
                .WithLocalizedMessage(() => ValidationMessages.NonUniquePostTitle);

            RuleFor(x => x.TitleTransliterated).NotEmpty().Length(0, 256);            
            RuleFor(x => x.Keywords).NotEmpty().Length(0, 128);
            RuleFor(x => x.Description).NotEmpty().Length(0, 512);
            RuleFor(x => x.Body).NotEmpty();
            RuleFor(x => x.State).NotNull();
            RuleFor(x => x.Tags).NotEmpty();
            RuleFor(x => x.Categories).NotEmpty();
        }

        private bool beUniqueTitle(string title)
        {
            return Post.FindByTitle(Query.Null, title) == null;
        }
    }
}