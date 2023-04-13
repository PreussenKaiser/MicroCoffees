using MicroCoffees.Mobile.Models;

namespace MicroCoffees.Mobile.Services;

/// <summary>
/// Implements commands and queries for coffees.
/// </summary>
public interface ICoffeeService
{
	/// <summary>
	/// Requests a <see cref="Coffee"/>.
	/// </summary>
	/// <param name="coffee">The <see cref="Coffee"/> to order.</param>
	/// <returns></returns>
	Task RequestCoffee(Coffee coffee);

	/// <summary>
	/// Gets a <see cref="Coffee"/>.
	/// </summary>
	/// <param name="id">The coffee's identifier.</param>
	/// <returns>
	/// The found <see cref="Coffee"/>,
	/// <see langword="null"/> if none were found.
	/// </returns>
	Task<Coffee?> FindAsync(Guid id);

	/// <summary>
	/// Gets a paginated list of coffees.
	/// </summary>
	/// <param name="page">The current page.</param>
	/// <param name="count">The amount of coffees to retrieve.</param>
	/// <returns>A list of coffees.</returns>
	Task<IEnumerable<Coffee>> SearchAsync(int page = 0, int count = 8);

	/// <summary>
	/// Sends a PATCH request to update a coffees quantity.
	/// </summary>
	/// <param name="id">The identifier of the <see cref="Coffee"/> to update.</param>
	/// <param name="qty">The new quantity.</param>
	/// <returns>Whether the task was completed or not.</returns>
	Task UpdateQuantityAsync(Guid id, int qty);

	/// <summary>
	/// Cancel's a <see cref="Coffee"/> request.
	/// </summary>
	/// <param name="id">References the <see cref="Coffee"/> request to cancel.</param>
	/// <returns>Whether the task was completed or not.</returns>
	Task CancelAsync(Guid id);
}
