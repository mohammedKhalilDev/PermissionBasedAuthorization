using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using PermissionBasedAuthorization.Core.Authorization;
using PermissionBasedAuthorization.Infrastructure.Context;

namespace PermissionBasedAuthorization.Modules
{
    public static class AuthorizationSetup
    {
        public static void AddAuthorizationServices(this IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();

            services.AddIdentity<AppUser, IdentityRole>(o =>
            {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 4;
            })
             .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                options.ValidationInterval = TimeSpan.Zero;
            });

        }
    }
}
