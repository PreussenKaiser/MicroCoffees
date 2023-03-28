using MediatR;
using MicroCoffees.Api.Application.Requests;
using MicroCoffees.Api.Infrastructure.Persistence;
using MicroCoffees.Domain.Entities.CoffeeAggregate;

namespace MicroCoffees.Api.Application.Handlers;

/// <summary>
/// 
/// </summary>
public sealed class ServeRequestHandler : IRequestHandler<ServeRequest, IResult>
{
	/// <summary>
	/// Th database to query.
	/// </summary>
	private readonly CoffeeContext context;

	/// <summary>
	/// Initializes the <see cref="ServeRequestHandler"/> class.
	/// </summary>
	/// <param name="context">The database to query.</param>
	public ServeRequestHandler(CoffeeContext context)
	{
		this.context = context;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<IResult> Handle(ServeRequest request, CancellationToken cancellationToken)
	{
		Coffee? coffee = await this.context.Coffees.FindAsync(
			request.Id, cancellationToken);

		if (coffee is null)
		{
			return Results.BadRequest();
		}

		try
		{
			coffee.Serve();

			await this.context.SaveChangesAsync();
		}
		catch (InvalidOperationException)
		{
			// TODO: Log

			return Results.Conflict();
		}

		return Results.Ok();
	}
}
