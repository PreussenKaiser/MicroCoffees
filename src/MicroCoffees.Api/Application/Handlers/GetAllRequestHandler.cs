using AutoMapper;
using MediatR;
using MicroCoffees.Api.Application.DTOs;
using MicroCoffees.Api.Application.Requests;
using MicroCoffees.Api.Infrastructure;
using MicroCoffees.Domain.Entities.CoffeeAggregate;
using Microsoft.EntityFrameworkCore;

namespace MicroCoffees.Api.Application.Handlers;

/// <summary>
/// 
/// </summary>
public sealed class GetAllRequestHandler : IRequestHandler<GetAllRequest, IEnumerable<CoffeeDto>>
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
	/// Initializes the <see cref="GetAllRequestHandler"/> class.
	/// </summary>
	/// <param name="coffeeRepository">The database to query.</param>
	/// <param name="mapper">Maps DTOs to entities.</param>
	public GetAllRequestHandler(ICoffeeRepository coffeeRepository, IMapper mapper)
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
	public async Task<IEnumerable<CoffeeDto>> Handle(GetAllRequest request, CancellationToken cancellationToken)
	{
		IEnumerable<CoffeeDto> coffees = (await this.coffeeRepository
			.GetAllAsync(request.Page, request.Count))
			.Select(c => this.mapper.Map<CoffeeDto>(c));

		return coffees;
	}
}
