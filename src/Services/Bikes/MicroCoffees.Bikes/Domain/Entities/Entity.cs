namespace MicroCoffees.Bikes.Domain.Entities;

/// <summary>
/// Represents a domain entity.
/// </summary>
public abstract class Entity
{
	/// <summary>
	/// Initializes the <see cref="Entity"/> class.
	/// </summary>
	public Entity()
	{
		this.Id = Guid.NewGuid();
	}

	/// <summary>
	/// Gets the entities identifier.
	/// </summary>
	public Guid Id { get; init; }
}
