using Festifact.Organisation.Services;
using Festifact.Organisation.View;

namespace Festifact.Organisation;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<FestivalService>();
        builder.Services.AddSingleton<MainpageViewModel>();

        builder.Services.AddSingleton<FestivalsPage>();

        builder.Services.AddTransient<FestivalsViewModel>();

        return builder.Build();
    }
}