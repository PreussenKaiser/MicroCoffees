using MicroCoffees.Domain.Entities.CoffeeAggregate;

namespace MicroCoffees.Api.Application.DTOs;

/// <summary>
/// Data transfer object representing an <see cref="Ingredient"/>.
/// </summary>
/// <param name="Id">The ingredient's unique identifier.</param>
/// <param name="Name">The ingredient's name.</param>
/// <param name="Cost">The ingredient's cost.</param>
public sealed record IngredientDto(
	Guid Id, string Name, decimal Cost);
