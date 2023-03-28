using MediatR;
using MicroCoffees.Api.Infrastructure.Persistence;
using MicroCoffees.Domain.Entities;

namespace MicroCoffees.Api.Infrastructure.Extensions;

public static class MediatorExtensions
{
    public static async Task DispatchEventsAsync(
        this IMediator mediator, CoffeeContext context)
    {
        var domainEntities = context.ChangeTracker
            .Entries<Entity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

        var domainEvents = domainEntities
            .SelectMany(x => x.Entity.DomainEvents)
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
