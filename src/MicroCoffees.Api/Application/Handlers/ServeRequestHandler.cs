using MediatR;
using MicroCoffees.Api.Application.Requests;
using MicroCoffees.Api.Infrastructure;
using MicroCoffees.Domain.Entities.CoffeeAggregate;

namespace MicroCoffees.Api.Application.Handlers;

/// <summary>
/// 
/// </summary>
public sealed class ServeRequestHandler : IRequestHandler<ServeRequest, bool>
{
	/// <summary>
	/// Th database to query.
	/// </summary>
	private readonly ICoffeeRepository coffeeRepository;

	/// <summary>
	/// Initializes the <see cref="ServeRequestHandler"/> class.
	/// </summary>
	/// <param name="coffeeRepository">The database to query.</param>
	public ServeRequestHandler(ICoffeeRepository coffeeRepository)
	{
		this.coffeeRepository = coffeeRepository;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<bool> Handle(ServeRequest request, CancellationToken cancellationToken)
	{
		Coffee? coffee = await this.coffeeRepository.FindAsync(request.Id);

		if (coffee is null)
		{
			return false;
		}

		try
		{
			coffee.Serve();

			await this.coffeeRepository
				.UnitOfWork
				.SaveChangesAsync(cancellationToken);
		}
		catch (InvalidOperationException)
		{
			// TODO: Log

			return false;
		}

		return true;
	}
}
