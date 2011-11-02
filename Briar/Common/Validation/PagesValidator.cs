using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using FluentValidation;

using Briar.Models;

namespace Briar.Common.Validation
{
    public class PagesValidator : AbstractValidator<Page>
    {
        public PagesValidator()
        {
            RuleFor(x => x.Title).NotEmpty().Length(0, 128);
            RuleFor(x => x.Url).NotEmpty().Length(0, 256);
            RuleFor(x => x.LayoutPath).NotEmpty().Length(0, 256);
            RuleFor(x => x.Keywords).NotEmpty().Length(0, 128);
            RuleFor(x => x.Description).NotEmpty().Length(0, 512);
            RuleFor(x => x.State).NotNull();
        }
    }
}