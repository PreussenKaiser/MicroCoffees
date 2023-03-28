using AutoMapper;
using MediatR;
using MicroCoffees.Api.Application.DTOs;
using MicroCoffees.Api.Application.Requests;
using MicroCoffees.Api.Infrastructure;
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
	/// Maps DTO's to entities.
	/// </summary>
	private readonly IMapper mapper;

	/// <summary>
	/// Initializes the <see cref="GetAllRequestHandler"/> class.
	/// </summary>
	/// <param name="context">The database to query.</param>
	/// <param name="mapper">Maps DTOs to entities.</param>
	public GetAllRequestHandler(CoffeeContext context, IMapper mapper)
	{
		this.context = context;
		this.mapper = mapper;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<IResult> Handle(GetAllRequest request, CancellationToken cancellationToken)
	{
		IEnumerable<CoffeeDto> coffees = await this.context.Coffees
			.Skip(request.Page)
			.Take(request.Count)
			.Include(c => c.Ingredients)
			.Select(c => this.mapper.Map<CoffeeDto>(c))
			.ToListAsync(cancellationToken);

		return Results.Ok(coffees);
	}
}
