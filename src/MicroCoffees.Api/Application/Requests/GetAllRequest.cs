namespace MicroCoffees.Api.Application.Requests;

/// <summary>
/// Represents a request to get a paginated list of coffees.
/// </summary>
/// <param name="Page">The page to start on.</param>
/// <param name="Count">The amount of coffees to get.</param>
public sealed record GetAllRequest(
	int Page = 0, int Count = 8) : IHttpRequest;
