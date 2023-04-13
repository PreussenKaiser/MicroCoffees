using MediatR;
using MicroCoffees.Coffees.Application.DTOs;

namespace MicroCoffees.Coffees.Application.Requests;

/// <summary>
/// A request to add a coffee to the API.
/// </summary>
/// <param name="Coffee">The coffee to add.</param>
public sealed record OrderCoffeeRequest(CoffeeDto Coffee) : IRequest<bool>;
