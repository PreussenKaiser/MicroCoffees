using MicroCoffees.Mobile.Models;
using MicroCoffees.Mobile.Services;

namespace MicroCoffees.Mobile.ViewModels;

/// <summary>
/// The view model for the '/coffees' page.
/// </summary>
internal sealed class CoffeesViewModel : PaginatedViewModel
{
	/// <summary>
	/// The service to get coffees from.
	/// </summary>
	private readonly ICoffeeService coffeeService;

	/// <summary>
	/// The coffees to display.
	/// </summary>
	private IEnumerable<Coffee> coffees;

	/// <summary>
	/// Initializes the <see cref="CoffeesViewModel"/> view model
	/// </summary>
	/// <param name="coffeeService">The service to get coffees from.</param>
	public CoffeesViewModel(ICoffeeService coffeeService)
	{
		this.coffeeService = coffeeService;
		this.coffees = Enumerable.Empty<Coffee>();

		this.Count = 9;
	}

	/// <summary>
	/// Gets the list of coffees to show.
	/// </summary>
	public IEnumerable<Coffee> Coffees
	{
		get => this.coffees;
		private set => this.SetProperty(ref this.coffees, value);
	}

	/// <summary>
	/// Refreshes the coffees list.
	/// </summary>
	/// <returns>Whether the task was completed or not.</returns>
	public async Task RefreshAsync()
	{
		this.Coffees = await this.coffeeService.SearchAsync(this.Page, this.Count);
	}

	/// <summary>
	/// Cancels a coffee order.
	/// </summary>
	/// <param name="parameter">The identifier of the coffee to cancel.</param>
	/// <returns>Whether the task was completed or not.</returns>
	public async Task CancelOrderAsync(object parameter)
	{
		if (parameter is not Guid coffeeId)
		{
			return;
		}

		await this.coffeeService.CancelAsync(coffeeId);

		await this.RefreshAsync();
	}

	/// <summary>
	/// Sets the quantity of a coffee.
	/// </summary>
	/// <remarks>Refreshes entire list when only one item is changed.</remarks>
	/// <param name="coffeeId">The identifier of the coffee being updated.</param>
	/// <param name="quantity">The new quantity.</param>
	/// <returns>Whether the task was completed or not.</returns>
	public async Task SetQuantityAsync(Guid coffeeId, int quantity)
	{
		if (quantity <= 0)
		{
			await this.coffeeService.CancelAsync(coffeeId);
		}
		else
		{
			await this.coffeeService.UpdateQuantityAsync(coffeeId, quantity);
		}

		await this.RefreshAsync();
	}

	/// <inheritdoc/>
	public override async Task NextAsync()
	{
		this.Page += this.Count;

		this.Coffees = await this.coffeeService.SearchAsync(this.Page, this.Count);
	}

	/// <inheritdoc/>
	public override async Task BackAsync()
	{
		this.Page = this.Page - this.Count >= 0
			? this.Page - this.Count
			: 0;

		this.Coffees = await this.coffeeService.SearchAsync(this.Page, this.Count);
	}
}
