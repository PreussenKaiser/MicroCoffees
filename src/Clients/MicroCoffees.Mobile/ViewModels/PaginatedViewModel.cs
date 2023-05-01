using System.Windows.Input;

namespace MicroCoffees.Mobile.ViewModels;

/// <summary>
/// <see cref="ViewModelBase"/> with pagination support.
/// </summary>
internal abstract class PaginatedViewModel : ViewModelBase
{
	/// <summary>
	/// The view's current page.
	/// </summary>
	private int page;

	/// <summary>
	/// Gets the view's current page.
	/// </summary>
	public int Page
	{
		get => this.page;
		protected set => this.SetProperty(ref this.page, value);
	}

	/// <summary>
	/// Gets the amount of items to display.
	/// </summary>
	public int Count { get; protected set; }

	/// <summary>
	/// Navigates to the next page,
	/// </summary>
	/// <returns>Whether the task was completed or not.</returns>
	public abstract Task NextAsync();

	/// <summary>
	/// Navigates to the previous page.
	/// </summary>
	/// <returns>Whether the task was completed or not.</returns>
	public abstract Task BackAsync();
}
