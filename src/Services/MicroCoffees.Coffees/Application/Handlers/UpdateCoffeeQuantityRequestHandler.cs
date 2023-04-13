using MediatR;
using MicroCoffees.Coffees.Application.Requests;
using MicroCoffees.Coffees.Domain.Entities.CoffeeAggregate;

namespace MicroCoffees.Coffees.Application.Handlers;

/// <summary>
/// Handles the <see cref="UpdateCoffeeQuantityRequest"/> command.
/// </summary>
public sealed class UpdateCoffeeQuantityRequestHandler : IRequestHandler<UpdateCoffeeQuantityRequest>
{
	/// <summary>
	/// The repository to execute against.
	/// </summary>
	private readonly ICoffeeRepository coffeeRepository;

	/// <summary>
	/// Initializes the <see cref="UpdateCoffeeQuantityRequestHandler"/> class.
	/// </summary>
	/// <param name="coffeeRepository">The repository to execute against.</param>
	public UpdateCoffeeQuantityRequestHandler(ICoffeeRepository coffeeRepository)
	{
		this.coffeeRepository = coffeeRepository;
	}

	/// <inheritdoc/>
	public async Task Handle(UpdateCoffeeQuantityRequest request, CancellationToken cancellationToken)
	{
		await this.coffeeRepository.UpdateQuantityAsync(
			request.Id, request.Quantity);

		await this.coffeeRepository
			.UnitOfWork
			.SaveChangesAsync(cancellationToken);
	}
}
