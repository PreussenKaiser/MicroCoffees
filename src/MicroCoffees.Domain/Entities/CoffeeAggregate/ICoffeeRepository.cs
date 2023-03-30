using MicroCoffees.Domain.Persistence;

namespace MicroCoffees.Domain.Entities.CoffeeAggregate;

/// <summary>
/// Implements query methods for <see cref="Coffee"/>.
/// </summary>
public interface ICoffeeRepository
{
	/// <summary>
	/// 
	/// </summary>
	public IUnitOfWork UnitOfWork { get; }

	/// <summary>
	/// Adds a <see cref="Coffee"/> to the shop.
	/// </summary>
	/// <param name="coffee">The <see cref="Coffee"/> to add.</param>
	/// <returns>Whether the task was completed or not.</returns>
	Task AddAsync(Coffee coffee);

	/// <summary>
	/// Gets all coffees from the shop.
	/// </summary>
	/// <returns>All coffees.</returns>
	Task<IEnumerable<Coffee>> GetAllAsync(int page = 0, int count = 8);

	/// <summary>
	/// Gets a <see cref="Coffee"/> from the shop.
	/// </summary>
	/// <param name="id">References the coffee to get.</param>
	/// <returns>
	/// The found <see cref="Coffee"/>.
	/// <see langword="null"/> if none were found.
	/// </returns>
	Task<Coffee?> FindAsync(Guid id);

	/// <summary>
	/// Removes a <see cref="Coffee"/> from the shop.
	/// </summary>
	/// <param name="coffee">The coffee to remove.</param>
	/// <returns>Whether the task was completed or not.</returns>
	Task RemoveAsync(Coffee coffee);
}
