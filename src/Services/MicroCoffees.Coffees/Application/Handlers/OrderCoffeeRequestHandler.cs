using MediatR;
using MicroCoffees.Coffees.Application.Requests;
using MicroCoffees.Coffees.Domain.Entities.CoffeeAggregate;

namespace MicroCoffees.Coffees.Application.Handlers;

/// <summary>
/// Handles the <see cref="OrderCoffeeRequest"/> command.
/// </summary>
public sealed class OrderCoffeeRequestHandler : IRequestHandler<OrderCoffeeRequest, bool>
{
	/// <summary>
	/// The database to query.
	/// </summary>
	private readonly ICoffeeRepository coffeeRepository;

	/// <summary>
	/// Initializes the <see cref="OrderCoffeeRequestHandler"/> class.
	/// </summary>
	/// <param name="coffeeRepository">The database to query.</param>
	public OrderCoffeeRequestHandler(ICoffeeRepository coffeeRepository)
	{
		this.coffeeRepository = coffeeRepository;
	}

	/// <inheritdoc/>
	public async Task<bool> Handle(OrderCoffeeRequest request, CancellationToken cancellationToken)
	{
		Coffee coffee = request.Coffee.To();

		await this.coffeeRepository.RequestAsync(coffee);

		await this.coffeeRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

		return true;
	}
}
