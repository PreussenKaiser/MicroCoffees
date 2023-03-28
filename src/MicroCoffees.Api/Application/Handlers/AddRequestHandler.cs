using MediatR;
using MicroCoffees.Api.Application.Requests;
using MicroCoffees.Api.Infrastructure.Persistence;

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
	/// Initializes the <see cref="AddRequestHandler"/> class.
	/// </summary>
	/// <param name="context">The database to query.</param>
	public AddRequestHandler(CoffeeContext context)
	{
		this.context = context;
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

		await this.context.Coffees.AddAsync(request.Coffee);

		await this.context.SaveChangesAsync();

		return Results.Created(string.Empty, request.Coffee);
	}
}
