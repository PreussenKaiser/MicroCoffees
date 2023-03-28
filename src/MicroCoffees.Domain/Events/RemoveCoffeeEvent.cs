using MicroCoffees.Domain.Entities.CoffeeAggregate;
using MediatR;

namespace MicroCoffees.Domain.Events;

/// <summary>
/// The event for removing a coffee.
/// </summary>
/// <param name="Id">The <see cref="Coffee"/> to remove.</param>
public sealed record RemoveCoffeeEvent(Guid Id) : INotification;
