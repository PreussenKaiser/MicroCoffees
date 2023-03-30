using MicroCoffees.Domain.Entities.CoffeeAggregate;
using MicroCoffees.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MicroCoffees.Api.Infrastructure.Repositories;

public sealed class CoffeeRepository : ICoffeeRepository
{
	private readonly CoffeeContext context;

	public CoffeeRepository(CoffeeContext context)
	{
		this.context = context;
	}

	public IUnitOfWork UnitOfWork
		=> this.context;

	public async Task AddAsync(Coffee coffee)
	{
		await this.context.AddAsync(coffee);
	}

	public async Task<IEnumerable<Coffee>> GetAllAsync(
		int page = 0, int count = 8)
	{
		IEnumerable<Coffee> coffees = await this.context.Coffees
			.AsNoTracking()
			.Skip(page)
			.Take(count)
			.ToListAsync();

		return coffees;
	}

	public async Task<Coffee?> FindAsync(Guid id)
	{
		Coffee? coffee = await this.context.Coffees.FirstOrDefaultAsync(c => c.Id == id);

		return coffee;
	}

	public Task RemoveAsync(Coffee coffee)
	{
		this.context.Coffees.Remove(coffee);

		return Task.CompletedTask;
	}
}
