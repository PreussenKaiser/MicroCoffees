using MediatR;

namespace MicroCoffees.Coffees.Application.Requests;

/// <summary>
/// Represents a request to cancel a coffee order.
/// </summary>
/// <param name="Id">The identifier of the order.</param>
public sealed record CancelCoffeeRequest(Guid Id) : IRequest;
