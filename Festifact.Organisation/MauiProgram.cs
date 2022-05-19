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

        builder.Services.AddTransient<FestivalsViewModel>();
        builder.Services.AddTransient<FestivalsPage>();

        builder.Services.AddTransient<FestivalDetailViewModel>();
        builder.Services.AddTransient<FestivalDetailPage>();

        builder.Services.AddTransient<PerformersViewModel>();
        builder.Services.AddTransient<PerformersPage>();

        builder.Services.AddTransient<LocationsViewModel>();
        builder.Services.AddTransient<LocationsPage>();


        return builder.Build();
    }
}
