using MicroCoffees.Mobile.Models;
using MicroCoffees.Mobile.Services;
using System.Windows.Input;

namespace MicroCoffees.Mobile.ViewModels;

/// <summary>
/// The view model for the '/coffees' page.
/// </summary>
internal sealed class CoffeesViewModel : ViewModelBase
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

		this.RefreshCommand = new Command(this.RefreshAsync);
		this.CancelOrderCommand = new Command(this.CancelOrderAsync);
	}

	/// <summary>
	/// Gets the command to refresh the page.
	/// </summary>
	public ICommand RefreshCommand { get; }

	/// <summary>
	/// Gets the command to update the quantity of a coffee.
	/// </summary>
	public ICommand SetQuantityCommand { get; }

	/// <summary>
	/// Gets the command to cancel a coffee order.
	/// </summary>
	public ICommand CancelOrderCommand { get; }

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
	private async void RefreshAsync()
	{
		this.Coffees = await this.coffeeService.SearchAsync();
	}

	/// <summary>
	/// Cancels a coffee order.
	/// </summary>
	/// <param name="parameter">The identifier of the coffee to cancel.</param>
	/// <returns>Whether the task was completed or not.</returns>
	private async void CancelOrderAsync(object parameter)
	{
		if (parameter is not Guid coffeeId)
		{
			return;
		}

		await this.coffeeService.CancelAsync(coffeeId);
	}

	private async void SetQuantityAsync(object parameter)
	{
	}
}
