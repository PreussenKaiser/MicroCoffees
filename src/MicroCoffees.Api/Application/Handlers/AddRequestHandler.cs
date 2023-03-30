using AutoMapper;
using MediatR;
using MicroCoffees.Api.Application.Requests;
using MicroCoffees.Api.Infrastructure;
using MicroCoffees.Domain.Entities.CoffeeAggregate;

namespace MicroCoffees.Api.Application.Handlers;

/// <summary>
/// 
/// </summary>
public sealed class AddRequestHandler : IRequestHandler<AddRequest, bool>
{
	/// <summary>
	/// The database to query.
	/// </summary>
	private readonly ICoffeeRepository coffeeRepository;

	/// <summary>
	/// Maps DTOs to entities.
	/// </summary>
	private readonly IMapper mapper;

	/// <summary>
	/// Initializes the <see cref="AddRequestHandler"/> class.
	/// </summary>
	/// <param name="coffeeRepository">The database to query.</param>
	public AddRequestHandler(ICoffeeRepository coffeeRepository, IMapper mapper)
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
	public async Task<bool> Handle(AddRequest request, CancellationToken cancellationToken)
	{
		Coffee coffee = this.mapper.Map<Coffee>(request.Coffee);

		await this.coffeeRepository.AddAsync(coffee);

		await this.coffeeRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

		return true;
	}
}
