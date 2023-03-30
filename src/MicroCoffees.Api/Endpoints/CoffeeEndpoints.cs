using MediatR;
using MicroCoffees.Api.Application.DTOs;
using MicroCoffees.Api.Application.Requests;

namespace MicroCoffees.Api.Endpoints;

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
		builder.MapPost(string.Empty, AddCoffeeAsync);
		builder.MapGet("page/{page:int?}/count/{count:int?}", GetCoffeesAsync);
		builder.MapGet("{id:guid}", GetCoffeeAsync);
		builder.MapPut("serve/{id:guid}", ServeCoffeeAsync);

		return builder;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="mediator"></param>
	/// <param name="request"></param>
	/// <returns></returns>
	private static async Task<IResult> AddCoffeeAsync(
		IMediator mediator, [AsParameters] AddRequest request)
	{
		await mediator.Send(request);

		return Results.Created($"/coffees/{request.Coffee.Id}", request.Coffee);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="mediator"></param>
	/// <param name="request"></param>
	/// <returns></returns>
	private static async Task<IResult> GetCoffeesAsync(
		IMediator mediator, [AsParameters] GetAllRequest request)
	{
		IEnumerable<CoffeeDto> coffees = await mediator.Send(request);

		return Results.Ok(coffees);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="mediator"></param>
	/// <param name="request"></param>
	/// <returns></returns>
	private static async Task<IResult> GetCoffeeAsync(
		IMediator mediator, [AsParameters] GetCoffeeRequest request)
	{
		CoffeeDto? coffee = await mediator.Send(request);

		if (coffee is null)
		{
			return Results.BadRequest();
		}

		return Results.Ok(coffee);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="mediator"></param>
	/// <param name="request"></param>
	/// <returns></returns>
	private static async Task<IResult> ServeCoffeeAsync(
		IMediator mediator, [AsParameters] ServeRequest request)
	{
		bool served = await mediator.Send(request);

		if (!served)
		{
			return Results.BadRequest();
		}

		return Results.Ok();
	}
}
