namespace MicroCoffees.Bikes.Domain.Entities.Bikes;

/// <summary>
/// Represents a bike.
/// </summary>
public sealed class Bike : Entity
{
	public Bike()
	{
		this.Name = string.Empty;
	}

	public string Name { get; init; }
}
