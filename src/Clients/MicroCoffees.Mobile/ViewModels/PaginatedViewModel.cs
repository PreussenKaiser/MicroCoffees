using System.Windows.Input;

namespace MicroCoffees.Mobile.ViewModels;

/// <summary>
/// <see cref="ViewModelBase"/> with pagination support.
/// </summary>
internal abstract class PaginatedViewModel : ViewModelBase
{
	/// <summary>
	/// Initializes the <see cref="PaginatedViewModel"/> abstract view model.
	/// </summary>
	protected PaginatedViewModel()
	{
		this.NextCommand = new Command(async () => await this.NextAsync());
		this.BackCommand = new Command(async () => await this.BackAsync());
	}

	/// <summary>
	/// Gets the view's current page.
	/// </summary>
	public int Page { get; protected set; }

	/// <summary>
	/// Gets the amount of items to display.
	/// </summary>
	public int Count { get; protected set; }

	/// <summary>
	/// Gets the command which navigates to the next page.
	/// </summary>
	public ICommand NextCommand { get; }

	/// <summary>
	/// Gets the command which navigates to the previous page.
	/// </summary>
	public ICommand BackCommand { get; }

	/// <summary>
	/// Navigates to the next page,
	/// </summary>
	/// <returns>Whether the task was completed or not.</returns>
	protected abstract Task NextAsync();

	/// <summary>
	/// Naviagest to the previous page.
	/// </summary>
	/// <returns>Whether the task was completed or not.</returns>
	protected abstract Task BackAsync();
}
