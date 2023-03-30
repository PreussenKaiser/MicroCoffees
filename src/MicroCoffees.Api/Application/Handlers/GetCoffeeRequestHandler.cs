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
public sealed class GetCoffeeRequestHandler : IRequestHandler<GetCoffeeRequest, CoffeeDto?>
{
	/// <summary>
	/// The database to query.
	/// </summary>
	private readonly ICoffeeRepository coffeeRepository;

	/// <summary>
	/// Maps entities to DTOs.
	/// </summary>
	private readonly IMapper mapper;

	/// <summary>
	/// Initializes the <see cref="GetCoffeeRequestHandler"/> class.
	/// </summary>
	/// <param name="coffeeRepository">The database to query.</param>
	/// <param name="mapper">Maps entities to DTOs.</param>
	public GetCoffeeRequestHandler(
		ICoffeeRepository coffeeRepository, IMapper mapper)
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
	public async Task<CoffeeDto?> Handle(GetCoffeeRequest request, CancellationToken cancellationToken)
	{
		Coffee? coffee = await this.coffeeRepository.FindAsync(request.Id);

		return this.mapper.Map<CoffeeDto>(coffee);
	}
}
