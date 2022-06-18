using Festifact.Visitor.View;
using Festifact.Visitor.Services;
using Microsoft.Extensions.Configuration;

namespace Festifact.Visitor;

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
        builder.Configuration.AddJsonFile("AppSettings.json");

		builder.Services.AddSingleton<FestivalService>();
		builder.Services.AddSingleton<ShowService>();
		builder.Services.AddSingleton<TicketService>();
		builder.Services.AddSingleton<VisitorService>();
		builder.Services.AddSingleton<ArtistService>();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<FestivalsViewModel>();

		builder.Services.AddTransient<FestivalsSearchViewModel>();
		builder.Services.AddTransient<FestivalSearchPage>();

        builder.Services.AddTransient<FestivalDetailsViewModel>();
        builder.Services.AddTransient<FestivalDetailsPage>();

        builder.Services.AddTransient<FestivalTicketViewModel>();
        builder.Services.AddTransient<FestivalTicketPage>();

        builder.Services.AddTransient<ShowViewModel>();
        builder.Services.AddTransient<ShowPage>();

        builder.Services.AddTransient<ArtistViewModel>();
        builder.Services.AddTransient<ArtistPage>();

        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<RegisterPage>();

        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<LoginPage>();

        builder.Services.AddTransient<AccountViewModel>();
        builder.Services.AddTransient<AccountPage>();

        builder.Services.AddTransient<FavoritesViewModel>();
        builder.Services.AddTransient<FavoritesPage>();

        builder.Services.AddTransient<VisitedShowsViewModel>();
        builder.Services.AddTransient<VisitedShowsPage>();

        return builder.Build();
	}
}
