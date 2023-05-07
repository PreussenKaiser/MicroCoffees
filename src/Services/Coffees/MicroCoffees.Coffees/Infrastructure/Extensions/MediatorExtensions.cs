using MediatR;
using MicroCoffees.Coffees.Domain.Entities;

namespace MicroCoffees.Coffees.Infrastructure.Extensions;

/// <summary>
/// Extension methods for <see cref="IMediator"/>.
/// </summary>
public static class MediatorExtensions
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="mediator"></param>
	/// <param name="context"></param>
	/// <returns></returns>
	public static async Task DispatchEventsAsync(
		this IMediator mediator, CoffeeContext context)
	{
		var domainEntities = context.ChangeTracker
			.Entries<Entity>()
			.Where(x =>
				x.Entity.DomainEvents is not null &&
				x.Entity.DomainEvents.Any());

		var domainEvents = domainEntities
			.SelectMany(entry => entry.Entity.DomainEvents)
			.ToList();

		domainEntities
			.ToList()
			.ForEach(entity => entity.Entity.ClearEvents());

		foreach (var domainEvent in domainEvents)
		{
			await mediator.Publish(domainEvent);
		}
	}
}
