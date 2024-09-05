using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;

namespace PermissionBasedAuthorization.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        //protected readonly ILogger _logger;
        //protected readonly IStringLocalizer _localizer;

        //public BaseController(ILogger logger, IStringLocalizer localizer)
        //{
        //    _logger = logger;
        //    _localizer = localizer;
        //}

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
                );

            return LocalRedirect(returnUrl);
        }

    }
}
