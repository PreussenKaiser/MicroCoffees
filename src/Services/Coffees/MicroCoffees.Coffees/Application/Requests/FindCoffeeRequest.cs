using MediatR;
using MicroCoffees.Coffees.Application.DTOs;

namespace MicroCoffees.Coffees.Application.Requests;

/// <summary>
/// Represents a request to get coffee.
/// </summary>
/// <param name="Id">References the coffee to get.</param>
public sealed record FindCoffeeRequest(Guid Id) : IRequest<CoffeeDto?>;
