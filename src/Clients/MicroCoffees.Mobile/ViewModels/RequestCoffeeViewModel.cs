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
	/// Facilitates routing on form submission.
	/// </summary>
	private readonly NavigationManager navigationManager;

	/// <summary>
	/// Initializes the <see cref="RequestCoffeeViewModel"/> view model.
	/// </summary>
	/// <param name="coffeeService">The service to request a coffee with.</param>
	/// <param name="navigationManager">Facilitates routing on form submission.</param>
	public RequestCoffeeViewModel(
		ICoffeeService coffeeService,
		NavigationManager navigationManager)
	{
		this.coffeeService = coffeeService;
		this.navigationManager = navigationManager;

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
	internal async Task SubmitAsync()
	{
		await this.coffeeService.RequestCoffee(this.Coffee);

		this.navigationManager.NavigateTo("/coffees");
	}
}
