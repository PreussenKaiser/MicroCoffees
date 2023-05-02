using MicroCoffees.Mobile.Services;
using MicroCoffees.Mobile.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MicroCoffees.Mobile;

/// <summary>
/// The application's entry-point.
/// </summary>
public static class MauiProgram
{
	/// <summary>
	/// Bootstraps the application.
	/// </summary>
	/// <returns>A configured <see cref="MauiApp"/>.</returns>
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

		builder.Services.AddHttpClient("coffees", client =>
		{
			client.BaseAddress = new Uri(Constants.CoffeesUrl);
		});

		builder.Services
			.AddSingleton<CoffeesViewModel>()
			.AddSingleton<RequestCoffeeViewModel>();

		builder.Services.AddScoped<ICoffeeService, CoffeeService>();

		return builder.Build();
	}
}