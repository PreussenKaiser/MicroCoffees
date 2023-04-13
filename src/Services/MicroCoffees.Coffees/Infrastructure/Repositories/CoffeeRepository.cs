using MicroCoffees.Coffees.Domain.Entities.CoffeeAggregate;
using MicroCoffees.Coffees.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MicroCoffees.Coffees.Infrastructure.Repositories;

/// <summary>
/// Executes commands and queries against an EF Core <see cref="DbContext"/>.
/// </summary>
public sealed class CoffeeRepository : ICoffeeRepository
{
	/// <summary>
	/// The <see cref="DbContext"/> to execute against.
	/// </summary>
	private readonly CoffeeContext context;

	/// <summary>
	/// Initializes the <see cref="CoffeeRepository"/> class.
	/// </summary>
	/// <param name="context">The <see cref="DbContext"/> to execute against.</param>
	public CoffeeRepository(CoffeeContext context)
	{
		this.context = context;
	}

	/// <inheritdoc/>
	public IUnitOfWork UnitOfWork
		=> this.context;

	/// <inheritdoc/>
	public async Task RequestAsync(Coffee coffee)
	{
		await this.context.AddAsync(coffee);
	}

	/// <inheritdoc/>
	public async Task<IEnumerable<Coffee>> SearchAsync(
		int page = 0, int count = 8)
	{
		IEnumerable<Coffee> coffees = await this.context.Coffees
			.AsNoTracking()
			.Skip(page)
			.Take(count)
			.ToListAsync();

		return coffees;
	}

	/// <inheritdoc/>
	public async Task<Coffee?> FindAsync(Guid id)
	{
		Coffee? coffee = await this.context.Coffees.FirstOrDefaultAsync(c => c.Id == id);

		return coffee;
	}

	/// <inheritdoc/>
	public async Task UpdateQuantityAsync(Guid id, int qty)
	{
		Coffee? coffee = await this.context.Coffees.FindAsync(id);

		if (coffee is null)
		{
			throw new ArgumentException(nameof(coffee));
		}

		coffee.UpdateQuantity(qty);
	}

	/// <inheritdoc/>
	public Task CancelAsync(Coffee coffee)
	{
		this.context.Coffees.Remove(coffee);

		return Task.CompletedTask;
	}
}
