using AutoMapper;
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
	/// Maps DTO's to entities.
	/// </summary>
	private readonly IMapper mapper;

	/// <summary>
	/// Initializes the <see cref="SearchCoffeesRequestHandler"/> class.
	/// </summary>
	/// <param name="coffeeRepository">The database to query.</param>
	/// <param name="mapper">Maps DTOs to entities.</param>
	public SearchCoffeesRequestHandler(ICoffeeRepository coffeeRepository, IMapper mapper)
	{
		this.coffeeRepository = coffeeRepository;
		this.mapper = mapper;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="request"></param>
	/// <param name="cancellationToken"></param>
	/// <returns></returns>
	public async Task<IEnumerable<CoffeeDto>> Handle(SearchCoffeesRequest request, CancellationToken cancellationToken)
	{
		IEnumerable<CoffeeDto> coffees = (await this.coffeeRepository
			.SearchAsync(request.Page, request.Count))
			.Select(c => this.mapper.Map<CoffeeDto>(c));

		return coffees;
	}
}
