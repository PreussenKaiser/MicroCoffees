using MicroCoffees.Domain.Entities.CoffeeAggregate;
using MediatR;

namespace MicroCoffees.Domain.Events;

/// <summary>
/// The event for removing a coffee.
/// </summary>
/// <param name="Coffee">The <see cref="Coffee"/> to remove.</param>
public sealed record RemoveCoffeeEvent(Coffee Coffee) : INotification;
