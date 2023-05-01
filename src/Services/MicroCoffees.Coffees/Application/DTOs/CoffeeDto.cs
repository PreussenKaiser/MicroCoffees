using MicroCoffees.Coffees.Domain.Entities;
using MicroCoffees.Coffees.Domain.Entities.CoffeeAggregate;
using MicroCoffees.Coffees.Domain.ValueObjects;

namespace MicroCoffees.Coffees.Application.DTOs;

/// <summary>
/// DTO for the <see cref="Coffee"/> entity.
/// </summary>
/// <param name="Id">The coffee's unique identifier.</param>
/// <param name="Name">The coffee's name.</param>
/// <param name="ImageUrl">A url leading to an image of the coffee.</param>
/// <param name="Cost">The coffee's cost.</param>
/// <param name="Quantity">The coffee's quantity.</param>
/// <param name="Roast">The coffee's roast.</param>
public sealed record CoffeeDto(
	Guid Id,
	string Name,
	string ImageUrl,
	decimal Cost,
	int Quantity,
	Roast Roast)
{
	/// <summary>
	/// Maps this instance to a <see cref="Coffee"/> domain entity.
	/// </summary>
	/// <returns>The mapped <see cref="Coffee"/>.</returns>
	public Coffee To()
	{
		return new Coffee(
			this.Name,
			this.ImageUrl,
			new CostUsd(this.Cost),
			new Quantity(this.Quantity),
			this.Roast);
	}

	/// <summary>
	/// Maps a <see cref="Coffee"/> domain entity to a new instance of this dto.
	/// </summary>
	/// <param name="coffee">The <see cref="Coffee"/> to map from.</param>
	/// <returns>A new instance of <see cref="CoffeeDto"/>.</returns>
	public static CoffeeDto From(Coffee coffee)
	{
		return new CoffeeDto(
			coffee.Id,
			coffee.Name,
			coffee.ImageUrl,
			coffee.Cost.Value,
			coffee.Quantity.Value,
			coffee.Roast);
	}
}