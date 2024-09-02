using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace PermissionBasedAuthorization.Views
{
    public abstract class AppRazorPage<TModel> : RazorPage<TModel>
    {
        [RazorInject]
        protected IAuthorizationService _authorizationService { get; set; }
        protected virtual bool IsGranted(string permissionName)
        {
            return _authorizationService.AuthorizeAsync(User, permissionName).Result.Succeeded;
        }
    }

}
