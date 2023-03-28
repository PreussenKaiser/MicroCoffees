using AutoMapper;
using MediatR;
using MicroCoffees.Api.Application.Requests;
using MicroCoffees.Api.Infrastructure;
using MicroCoffees.Domain.Entities.CoffeeAggregate;

namespace MicroCoffees.Api.Application.Handlers;

/// <summary>
/// 
/// </summary>
public sealed class AddRequestHandler : IRequestHandler<AddRequest, IResult>
{
	/// <summary>
	/// The database to query.
	/// </summary>
	private readonly CoffeeContext context;

	/// <summary>
	/// Maps DTOs to entities.
	/// </summary>
	private readonly IMapper mapper;

	/// <summary>
	/// Initializes the <see cref="AddRequestHandler"/> class.
	/// </summary>
	/// <param name="context">The database to query.</param>
	public AddRequestHandler(CoffeeContext context, IMapper mapper)
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
	public async Task<IResult> Handle(AddRequest request, CancellationToken cancellationToken)
	{
		// TODO: Validation

		Coffee coffee = this.mapper.Map<Coffee>(request.Coffee);

		await this.context.Coffees.AddAsync(coffee, cancellationToken);

		await this.context.SaveChangesAsync(cancellationToken);

		return Results.Created($"/coffees/{coffee.Id}", request.Coffee);
	}
}
