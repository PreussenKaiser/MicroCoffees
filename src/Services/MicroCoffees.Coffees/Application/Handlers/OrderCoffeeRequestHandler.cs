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
	/// Logs request handling.
	/// </summary>
	private readonly ILogger<OrderCoffeeRequestHandler> logger;

	/// <summary>
	/// Initializes the <see cref="OrderCoffeeRequestHandler"/> class.
	/// </summary>
	/// <param name="coffeeRepository">The database to query.</param>
	/// <param name="logger">Logs request processes.</param>
	public OrderCoffeeRequestHandler(
		ICoffeeRepository coffeeRepository,
		ILogger<OrderCoffeeRequestHandler> logger)
	{
		this.coffeeRepository = coffeeRepository;
		this.logger = logger;
	}

	/// <inheritdoc/>
	public async Task<bool> Handle(OrderCoffeeRequest request, CancellationToken cancellationToken)
	{
		Coffee coffee = request.Coffee.To();

		await this.coffeeRepository.RequestAsync(coffee);

		await this.coffeeRepository
			.UnitOfWork
			.SaveChangesAsync(cancellationToken);

		Coffee? requestedCoffee = await this.coffeeRepository.FindAsync(coffee.Id);

		if (requestedCoffee is null)
		{
			this.logger.LogWarning($"{request.Coffee.Name} order failed.");

			return false;
		}

		this.logger.LogInformation($"{requestedCoffee.Name} ordered.");

		return true;
	}
}
