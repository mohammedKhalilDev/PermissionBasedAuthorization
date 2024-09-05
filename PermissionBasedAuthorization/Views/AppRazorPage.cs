using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.Extensions.Localization;

namespace PermissionBasedAuthorization.Views
{
    public abstract class AppRazorPage<TModel> : RazorPage<TModel>
    {
        [RazorInject]
        protected IAuthorizationService _authorizationService { get; set; }

        [RazorInject]
        protected IStringLocalizer _localizer { get; set; }

        protected virtual bool IsGranted(string permissionName)
        {
            return _authorizationService.AuthorizeAsync(User, permissionName).Result.Succeeded;
        }

        protected virtual string L(string name)
        {
            return _localizer.GetString(name);
        }
    }

}
