using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Briar.Common.ActionFilters;

using Shamrock.Web.Mvc;

namespace Briar.Common.Controllers
{
    [FontendActionFilter]
    [MainMenuActionFilter]
    public class FrontendController : ControllerBase
    {
    }
}