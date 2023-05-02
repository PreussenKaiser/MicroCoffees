using MicroCoffees.Mobile.Models;
using MicroCoffees.Mobile.Services;
using Microsoft.AspNetCore.Components;

namespace MicroCoffees.Mobile.ViewModels;

/// <summary>
/// The view model for requesting coffees.
/// </summary>
internal sealed class RequestCoffeeViewModel : ViewModelBase
{
	/// <summary>
	/// The service to request a coffee with.
	/// </summary>
	private readonly ICoffeeService coffeeService;

	/// <summary>
	/// Initializes the <see cref="RequestCoffeeViewModel"/> view model.
	/// </summary>
	/// <param name="coffeeService">The service to request a coffee with.</param>
	/// <param name="navigationManager">Facilitates routing on form submission.</param>
	public RequestCoffeeViewModel(ICoffeeService coffeeService)
	{
		this.coffeeService = coffeeService;

		this.Coffee = new();
	}

	/// <summary>
	/// The coffee to request.
	/// </summary>
	public Coffee Coffee { get; set; }

	/// <summary>
	/// Handles a successful form submission.
	/// </summary>
	/// <returns>Whether the task was completed or not.</returns>
	internal async Task SubmitAsync(NavigationManager navigationManager)
	{
		ArgumentNullException.ThrowIfNull(
			navigationManager, nameof(navigationManager));

		await this.coffeeService.RequestCoffee(this.Coffee);

		navigationManager?.NavigateTo("/coffees");
	}
}
