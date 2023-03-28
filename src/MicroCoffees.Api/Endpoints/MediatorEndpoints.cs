using MediatR;
using MicroCoffees.Api.Application;

namespace MicroCoffees.Api.Endpoints;

/// <summary>
/// Configures endpoints for '/api/coffee'.
/// </summary>
public static class MediatorEndpoints
{
	/// <summary>
	/// Maps a POST request to a MediatR request.
	/// </summary>
	/// <typeparam name="TRequest">The type of request to send.</typeparam>
	/// <param name="builder">The app to map GET to.</param>
	/// <param name="template">Url for the endpoint.</param>
	/// <returns>The comfigured web application.</returns>
	public static IEndpointRouteBuilder MediatePost<TRequest>(
		this IEndpointRouteBuilder builder, string template = "") where TRequest : IHttpRequest
	{
		builder.MapPost(template,
			async (IMediator mediator, [AsParameters] TRequest request)
				=> await mediator.Send(request));

		return builder;
	}

	/// <summary>
	/// Maps a GET request to a MediatR request.
	/// </summary>
	/// <typeparam name="TRequest">The type of request to send.</typeparam>
	/// <param name="builder">The app to map GET to.</param>
	/// <param name="template">Url for the endpoint.</param>
	/// <returns>The comfigured web application.</returns>
	public static IEndpointRouteBuilder MediateGet<TRequest>(
		this IEndpointRouteBuilder builder, string template = "") where TRequest : IHttpRequest
	{
		builder.MapGet(template,
			async (IMediator mediator, [AsParameters] TRequest request)
				=> await mediator.Send(request));

		return builder;
	}

	/// <summary>
	/// Maps a PUT request to a MediatR request.
	/// </summary>
	/// <typeparam name="TRequest">The type of request to send.</typeparam>
	/// <param name="builder">The app to map GET to.</param>
	/// <param name="template">Url for the endpoint.</param>
	/// <returns>The comfigured web application.</returns>
	public static IEndpointRouteBuilder MediatePut<TRequest>(
		this IEndpointRouteBuilder builder, string template = "") where TRequest : IHttpRequest
	{
		builder.MapPut(template,
			async (IMediator mediator, [AsParameters] TRequest request)
				=> await mediator.Send(request));

		return builder;
	}

	/// <summary>
	/// Maps a PATCH request to a MediatR request.
	/// </summary>
	/// <typeparam name="TRequest">The type of request to send.</typeparam>
	/// <param name="builder">The app to map GET to.</param>
	/// <param name="template">Url for the endpoint.</param>
	/// <returns>The comfigured web application.</returns>
	public static IEndpointRouteBuilder MediatePatch<TRequest>(
		this IEndpointRouteBuilder builder, string template = "") where TRequest : IHttpRequest
	{
		builder.MapPatch(template,
			async (IMediator mediator, [AsParameters] TRequest request)
				=> await mediator.Send(request));

		return builder;
	}

	/// <summary>
	/// Maps a DELETE request to a MediatR request.
	/// </summary>
	/// <typeparam name="TRequest">The type of request to send.</typeparam>
	/// <param name="builder">The app to map GET to.</param>
	/// <param name="template">Url for the endpoint.</param>
	/// <returns>The comfigured web application.</returns>
	public static IEndpointRouteBuilder MediateDelete<TRequest>(
		this IEndpointRouteBuilder builder, string template = "") where TRequest : IHttpRequest
	{
		builder.MapDelete(template,
			async (IMediator mediator, [AsParameters] TRequest request)
				=> await mediator.Send(request));

		return builder;
	}
}
