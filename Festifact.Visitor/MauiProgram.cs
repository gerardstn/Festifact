﻿using Festifact.Visitor.View;
using Festifact.Visitor.Services;

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

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<FestivalService>();
		builder.Services.AddSingleton<FestivalsViewModel>();

		builder.Services.AddTransient<FestivalSearchViewModel>();
		builder.Services.AddTransient<SearchPage>(); 

		builder.Services.AddTransient<FestivalDetailsViewModel>();
		builder.Services.AddTransient<DetailsPage>();

		return builder.Build();
	}
}
