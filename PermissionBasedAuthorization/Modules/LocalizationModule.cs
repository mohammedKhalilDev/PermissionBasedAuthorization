using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Localization;
using PermissionBasedAuthorization.Core.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionBasedAuthorization.Authorization.Module
{
    public static class LocalizationSetup
    {
        public static void AddLocalizationServices(this IServiceCollection services)
        {
            services.AddLocalization();
            services.AddDistributedMemoryCache();

            services.AddSingleton<IStringLocalizer, JsonStringLocalizer>();
            services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(JsonStringLocalizerFactory));
                });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                new CultureInfo("ar-EG"),
                new CultureInfo("en-US"),
            };

                options.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0], uiCulture: supportedCultures[0]);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }

        public static void AddLocalizationMiddlewares(this WebApplication app)
        {

            var supportedCultures = new[] { "ar-EG", "en-US" };
            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);
        }

    }
}
