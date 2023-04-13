using MediatR;
using MicroCoffees.Coffees.Application.DTOs;
using MicroCoffees.Coffees.Application.Requests;

namespace MicroCoffees.Coffees.Endpoints;

/// <summary>
/// Contains endpoints for 'api/coffee'.
/// </summary>
public static class CoffeeEndpoints
{
	/// <summary>
	/// Maps coffee endpoints to the application.
	/// </summary>
	/// <param name="builder">The application to configure.</param>
	/// <returns>The application with coffee endpoints.</returns>
	public static IEndpointRouteBuilder MapCoffees(this IEndpointRouteBuilder builder)
	{
		builder.MapPost(string.Empty, OrderCoffeeAsync);
		builder.MapGet("page/{page:int?}/count/{count:int?}", SearchCoffeesAsync);
		builder.MapGet("{id:guid}", FindCoffeeAsync);
		builder.MapPatch("{id:guid}", UpdateQuantityAsync);
		builder.MapDelete("{id:guid}", CancelAsync);

		return builder;
	}

	/// <summary>
	/// POST request to place an order for coffee.
	/// </summary>
	/// <param name="mediator">Request dispatcher.</param>
	/// <param name="request">The request to dispatch.</param>
	/// <returns></returns>
	private static async Task<IResult> OrderCoffeeAsync(
		IMediator mediator, [AsParameters] OrderCoffeeRequest request)
	{
		await mediator.Send(request);

		return Results.Created($"/coffees/{request.Coffee.Id}", request.Coffee);
	}

	/// <summary>
	/// GET request to return a paginated list of coffees.
	/// </summary>
	/// <param name="mediator">Request dispatcher.</param>
	/// <param name="request">The request to dispatch.</param>
	/// <returns></returns>
	private static async Task<IResult> SearchCoffeesAsync(
		IMediator mediator, [AsParameters] SearchCoffeesRequest request)
	{
		IEnumerable<CoffeeDto> coffees = await mediator.Send(request);

		return Results.Ok(coffees);
	}

	/// <summary>
	/// GET request to find a coffee by it's identifier.
	/// </summary>
	/// <param name="mediator">Request dispatcher.</param>
	/// <param name="request">The request to dispatch.</param>
	/// <returns></returns>
	private static async Task<IResult> FindCoffeeAsync(
		IMediator mediator, [AsParameters] FindCoffeeRequest request)
	{
		CoffeeDto? coffee = await mediator.Send(request);

		if (coffee is null)
		{
			return Results.BadRequest();
		}

		return Results.Ok(coffee);
	}

	/// <summary>
	/// PATCH request to update a coffee's quantity.
	/// </summary>
	/// <param name="mediator">Request dispatcher.</param>
	/// <param name="request">The request to dispatch.</param>
	/// <returns></returns>
	private static async Task<IResult> UpdateQuantityAsync(
		IMediator mediator, [AsParameters] UpdateCoffeeQuantityRequest request)
	{
		await mediator.Send(request);

		return Results.Ok();
	}

	/// <summary>
	/// DELETE request to cancel a order.
	/// </summary>
	/// <param name="mediator">Request dispatcher.</param>
	/// <param name="request">The request to dispatch.</param>
	/// <returns></returns>
	private static async Task<IResult> CancelAsync(
		IMediator mediator, [AsParameters] CancelCoffeeRequest request)
	{
		await mediator.Send(request);

		return Results.Ok();
	}
}
