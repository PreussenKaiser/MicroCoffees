using MicroCoffees.Domain.Entities.CoffeeAggregate;

namespace MicroCoffees.Api.Application.Requests;

/// <summary>
/// Serves the referenced <see cref="Coffee"/>.
/// </summary>
/// <param name="Id"></param>
public sealed record ServeRequest(Guid Id) : IHttpRequest;
