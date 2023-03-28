using MediatR;

namespace MicroCoffees.Api.Application;

/// <summary>
/// Implements an HTTP request.
/// </summary>
public interface IHttpRequest : IRequest<IResult>
{
}
