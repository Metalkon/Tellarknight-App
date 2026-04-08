using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Storage;
using Microsoft.Extensions.Logging;
using TellarknightApp.Models;
using TellarknightApp.Services;

namespace TellarknightApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services
                .AddSingleton<IFileSaver>(FileSaver.Default)
                .AddSingleton<CardManager>()
                .AddSingleton<StatisticsManager>()
                .AddSingleton<SupportedCards>()
                .AddSingleton<Decklist>(); // old/remove later


#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
