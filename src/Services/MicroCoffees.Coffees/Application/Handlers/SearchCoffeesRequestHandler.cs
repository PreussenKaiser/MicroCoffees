using MediatR;
using MicroCoffees.Coffees.Application.DTOs;
using MicroCoffees.Coffees.Application.Requests;
using MicroCoffees.Coffees.Domain.Entities.CoffeeAggregate;

namespace MicroCoffees.Coffees.Application.Handlers;

/// <summary>
/// Handles the <see cref="SearchCoffeesRequest"/> query.
/// </summary>
public sealed class SearchCoffeesRequestHandler : IRequestHandler<SearchCoffeesRequest, IEnumerable<CoffeeDto>>
{
	/// <summary>
	/// The database to query.
	/// </summary>
	private readonly ICoffeeRepository coffeeRepository;

	/// <summary>
	/// Logs request processes.
	/// </summary>
	private readonly ILogger<SearchCoffeesRequestHandler> logger;

	/// <summary>
	/// Initializes the <see cref="SearchCoffeesRequestHandler"/> class.
	/// </summary>
	/// <param name="coffeeRepository">The database to query.</param>
	/// <param name="logger">Logs request processes.</param>
	public SearchCoffeesRequestHandler(
		ICoffeeRepository coffeeRepository,
		ILogger<SearchCoffeesRequestHandler> logger)
	{
		this.coffeeRepository = coffeeRepository;
		this.logger = logger;
	}

	/// <inheri
	public async Task<IEnumerable<CoffeeDto>> Handle(SearchCoffeesRequest request, CancellationToken cancellationToken)
	{
		IEnumerable<CoffeeDto> coffees = (await this.coffeeRepository
			.SearchAsync(request.Page, request.Count))
			.Select(CoffeeDto.From);

		this.logger.LogInformation(
			$"{request.Count} coffees were queried with {request.Page} skipped.");

		return coffees;
	}
}
