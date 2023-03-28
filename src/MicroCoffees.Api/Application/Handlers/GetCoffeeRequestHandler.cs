using MediatR;
using MicroCoffees.Api.Application.Requests;
using MicroCoffees.Api.Infrastructure.Persistence;
using MicroCoffees.Domain.Entities.CoffeeAggregate;
using Microsoft.EntityFrameworkCore;

namespace MicroCoffees.Api.Application.Handlers;

/// <summary>
/// 
/// </summary>
public sealed class GetCoffeeRequestHandler : IRequestHandler<GetCoffeeRequest, IResult>
{
	/// <summary>
	/// The database to query.
	/// </summary>
	private readonly CoffeeContext context;

	/// <summary>
	/// Initializes the <see cref="GetCoffeeRequestHandler"/> class.
	/// </summary>
	/// <param name="context">The database to query.</param>
	public GetCoffeeRequestHandler(CoffeeContext context)
	{
		this.context = context;	
	}

	public async Task<IResult> Handle(GetCoffeeRequest request, CancellationToken cancellationToken)
	{
		Coffee? coffee = await this.context.Coffees
			.AsNoTracking()
			.FirstOrDefaultAsync(c => c.Id == request.Id);

		if (coffee is null)
		{
			return Results.BadRequest();
		}

		return Results.Ok(coffee);
	}
}
