﻿using MicroCoffees.Coffees.Domain.Entities.CoffeeAggregate;

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
	Roast Roast);