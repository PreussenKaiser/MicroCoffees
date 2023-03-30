using MediatR;
using MicroCoffees.Domain.Entities.CoffeeAggregate;
using MicroCoffees.Domain.Events;

namespace MicroCoffees.Api.Application.Handlers;

/// <summary>
/// 
/// </summary>
public sealed class RemoveCoffeeEventHandler : INotificationHandler<RemoveCoffeeEvent>
{
	/// <summary>
	/// Coffees to execute the delete command against.
	/// </summary>
	private readonly ICoffeeRepository coffeeRepository;

	/// <summary>
	/// Initializes the <see cref="RemoveCoffeeEventHandler"/> class.
	/// </summary>
	/// <param name="coffeeRepository">Coffees to execute the delete command against.</param>
	public RemoveCoffeeEventHandler(ICoffeeRepository coffeeRepository)
	{
		this.coffeeRepository = coffeeRepository;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="notification"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task Handle(RemoveCoffeeEvent notification, CancellationToken cancellationToken)
	{
		await this.coffeeRepository.RemoveAsync(notification.Coffee);

		await this.coffeeRepository
			.UnitOfWork
			.SaveChangesAsync(cancellationToken);
	}
}
