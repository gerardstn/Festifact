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

        builder.Services.AddSingleton<FestivalService>();
        builder.Services.AddSingleton<ShowService>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainpageViewModel>();

        builder.Services.AddTransient<FestivalsViewModel>();
        builder.Services.AddTransient<FestivalsPage>();

        builder.Services.AddTransient<FestivalAddViewModel>();
        builder.Services.AddTransient<FestivalAddPage>();

        builder.Services.AddTransient<FestivalEditViewModel>();
        builder.Services.AddTransient<FestivalEditPage>();


        builder.Services.AddTransient<ShowAddViewModel>();
        builder.Services.AddTransient<ShowAddPage>();

        builder.Services.AddTransient<ShowEditViewModel>();
        builder.Services.AddTransient<ShowEditPage>();


        builder.Services.AddTransient<PerformersViewModel>();
        builder.Services.AddTransient<PerformersPage>();

        builder.Services.AddTransient<PerformerAddViewModel>();
        builder.Services.AddTransient<PerformerAddPage>();

        builder.Services.AddTransient<PerformerEditViewModel>();
        builder.Services.AddTransient<PerformerEditPage>();


        builder.Services.AddTransient<LocationsViewModel>();
        builder.Services.AddTransient<LocationsPage>();

        builder.Services.AddTransient<LocationAddViewModel>();
        builder.Services.AddTransient<LocationAddPage>();

        builder.Services.AddTransient<LocationEditViewModel>();
        builder.Services.AddTransient<LocationEditPage>();


        return builder.Build();
    }
}
