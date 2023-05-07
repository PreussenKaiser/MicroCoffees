using MediatR;
using MicroCoffees.Coffees.Application.DTOs;

namespace MicroCoffees.Coffees.Application.Requests;

/// <summary>
/// Represents a request to get a paginated list of coffees.
/// </summary>
/// <param name="Page">The page to start on.</param>
/// <param name="Count">The amount of coffees to get.</param>
public sealed record SearchCoffeesRequest(
	int Page = 0, int Count = 8) : IRequest<IEnumerable<CoffeeDto>>;
