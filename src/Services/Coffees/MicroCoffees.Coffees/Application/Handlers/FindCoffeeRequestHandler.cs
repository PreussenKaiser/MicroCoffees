using MediatR;
using MicroCoffees.Coffees.Application.DTOs;
using MicroCoffees.Coffees.Application.Requests;
using MicroCoffees.Coffees.Domain.Entities.CoffeeAggregate;

namespace MicroCoffees.Coffees.Application.Handlers;

/// <summary>
/// Handles the <see cref="FindCoffeeRequest"/> query.
/// </summary>
public sealed class FindCoffeeRequestHandler : IRequestHandler<FindCoffeeRequest, CoffeeDto?>
{
	/// <summary>
	/// The database to query.
	/// </summary>
	private readonly ICoffeeRepository coffeeRepository;

	/// <summary>
	/// Initializes the <see cref="FindCoffeeRequestHandler"/> class.
	/// </summary>
	/// <param name="coffeeRepository">The database to query.</param>
	public FindCoffeeRequestHandler(ICoffeeRepository coffeeRepository)
	{
		this.coffeeRepository = coffeeRepository;
	}

	/// <inheritdoc/>
	public async Task<CoffeeDto?> Handle(FindCoffeeRequest request, CancellationToken cancellationToken)
	{
		Coffee? coffee = await this.coffeeRepository.FindAsync(request.Id);

		return CoffeeDto.From(coffee);
	}
}
