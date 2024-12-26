#if ANDROID
using BlazorHybridCRUDwithSQLite.Platforms.Android;
#endif
using Microsoft.Extensions.Logging;

namespace BlazorHybridCRUDwithSQLite
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });
#if ANDROID
            builder.Services.AddScoped<IPathProvider, AndroidPathProvider>();
#endif
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddScoped<IUserProfile>(serviceProvider =>
            {
                var pathProvider = serviceProvider.GetRequiredService<IPathProvider>();
                var dbPath = pathProvider.GetDatabasePath("userprofile.db3");
                return new UserProfileService(dbPath);
            });

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
