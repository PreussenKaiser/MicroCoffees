using MediatR;

namespace MicroCoffees.Coffees.Application.Requests;

/// <summary>
/// Represents a request to update a coffee request's quantity.
/// </summary>
/// <param name="Id">The request's identifier.</param>
/// <param name="Quantity">The new quantity.</param>
public sealed record UpdateCoffeeQuantityRequest(Guid Id, int Quantity) : IRequest;
