using MicroCoffees.Api.Application.DTOs;

namespace MicroCoffees.Api.Application.Requests;

/// <summary>
/// A request to add a coffee to the API.
/// </summary>
/// <param name="Coffee">The coffee to add.</param>
public sealed record AddRequest(CoffeeDto Coffee) : IHttpRequest;
