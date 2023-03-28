using MediatR;
using MicroCoffees.Api.Application.Requests;
using MicroCoffees.Api.Infrastructure.Persistence;
using MicroCoffees.Domain.Entities.CoffeeAggregate;
using Microsoft.EntityFrameworkCore;

namespace MicroCoffees.Api.Application.Handlers;

/// <summary>
/// 
/// </summary>
public sealed class GetAllRequestHandler : IRequestHandler<GetAllRequest, IResult>
{
	/// <summary>
	/// The database to query.
	/// </summary>
	private readonly CoffeeContext context;

	/// <summary>
	/// Initializes the <see cref="GetAllRequestHandler"/> class.
	/// </summary>
	/// <param name="context">The database to query.</param>
	public GetAllRequestHandler(CoffeeContext context)
	{
		this.context = context;	
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	/// <exception cref="NotImplementedException"></exception>
	public async Task<IResult> Handle(GetAllRequest request, CancellationToken cancellationToken)
	{
		IEnumerable<Coffee> coffees = await this.context.Coffees
			.Skip(request.Page)
			.Take(request.Count)
			.ToListAsync(cancellationToken);

		return Results.Ok(coffees);
	}
}
