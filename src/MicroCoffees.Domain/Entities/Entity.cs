using MediatR;
using System.Collections.ObjectModel;

namespace MicroCoffees.Domain.Entities;

/// <summary>
/// Represents an entity in the domain.
/// </summary>
public abstract class Entity
{
    /// <summary>
    /// Events to call.
    /// </summary>
    private readonly List<INotification> domainEvents;

    /// <summary>
    /// Initializes the <see cref="Entity"/> class.
    /// </summary>
    public Entity()
    {
        this.Id = Guid.NewGuid();
        this.domainEvents = new List<INotification>();
    }

    /// <summary>
    /// The entity's unique identifier.
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Events to call.
    /// </summary>
    public ReadOnlyCollection<INotification> DomainEvents
        => this.domainEvents.AsReadOnly();

    /// <summary>
    /// Removes all events from the <see cref="Entity"/>.
    /// </summary>
    public void ClearEvents()
    {
        this.domainEvents.Clear();
    }

    /// <summary>
    /// Adds a domain event to the <see cref="Entity"/>.
    /// </summary>
    /// <param name="domainEvent">The <see cref="INotification"/> to add.</param>
    protected void AddEvent(INotification domainEvent)
    {
        this.domainEvents.Add(domainEvent);
    }
}
