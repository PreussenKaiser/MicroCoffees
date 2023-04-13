using MediatR;
using MicroCoffees.Coffees.Application.Requests;
using MicroCoffees.Coffees.Domain.Entities.CoffeeAggregate;

namespace MicroCoffees.Coffees.Application.Handlers;

/// <summary>
/// Handles the <see cref="CancelCoffeeRequestHandler"/> command.
/// </summary>
public sealed class CancelCoffeeRequestHandler : IRequestHandler<CancelCoffeeRequest>
{
	/// <summary>
	/// Coffees to execute the delete command against.
	/// </summary>
	private readonly ICoffeeRepository coffeeRepository;

	/// <summary>
	/// Initializes the <see cref="CancelCoffeeRequestHandler"/> class.
	/// </summary>
	/// <param name="coffeeRepository">Coffees to execute the delete command against.</param>
	public CancelCoffeeRequestHandler(ICoffeeRepository coffeeRepository)
	{
		this.coffeeRepository = coffeeRepository;
	}

	/// <inheritdoc/>
	public async Task Handle(CancelCoffeeRequest request, CancellationToken cancellationToken)
	{
		Coffee? coffee = await this.coffeeRepository.FindAsync(request.Id);

		if (coffee is null)
		{
			throw new ArgumentException(nameof(coffee));
		}

		await this.coffeeRepository.CancelAsync(coffee);

		await this.coffeeRepository
			.UnitOfWork
			.SaveChangesAsync(cancellationToken);
	}
}
