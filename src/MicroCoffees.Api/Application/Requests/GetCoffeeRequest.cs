namespace MicroCoffees.Api.Application.Requests;

/// <summary>
/// Represents a request to get coffee.
/// </summary>
/// <param name="Id">References the coffee to get.</param>
public sealed record GetCoffeeRequest(Guid Id) : IHttpRequest;
