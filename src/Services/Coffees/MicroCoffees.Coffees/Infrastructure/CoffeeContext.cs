using MediatR;
using MicroCoffees.Coffees.Infrastructure.Extensions;
using MicroCoffees.Coffees.Domain.Entities.CoffeeAggregate;
using MicroCoffees.Coffees.Domain.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MicroCoffees.Coffees.Infrastructure;

/// <summary>
/// The database to persist our coffee shop with.
/// </summary>
public sealed class CoffeeContext : DbContext, IUnitOfWork
{
	/// <summary>
	/// Event dispatcher.
	/// </summary>
	private readonly IMediator mediator;

	/// <summary>
	/// Initializes the <see cref="CoffeeContext"/> class.
	/// </summary>
	/// <param name="options">Database options.</param>
	/// <param name="mediator">Event dispatcher.</param>
	public CoffeeContext(
		DbContextOptions<CoffeeContext> options,
		IMediator mediator) : base(options)
	{
		this.mediator = mediator;
	}

	/// <summary>
	/// Coffees in the database.
	/// </summary>
	public DbSet<Coffee> Coffees { get; set; }

	/// <summary>
	/// Persists changes in the database and calls all domain events.
	/// </summary>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
	{
		await this.mediator.DispatchEventsAsync(this);

		int result = await base.SaveChangesAsync(cancellationToken);

		return result;
	}

	/// <summary>
	/// Applies entity configurations.
	/// </summary>
	/// <param name="modelBuilder">API for configuring entities.</param>
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoffeeContext).Assembly);
	}
}
