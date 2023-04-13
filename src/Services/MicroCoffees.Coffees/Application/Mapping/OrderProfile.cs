using AutoMapper;
using MicroCoffees.Coffees.Application.DTOs;
using MicroCoffees.Coffees.Domain.Entities.CoffeeAggregate;

namespace MicroCoffees.Coffees.Application.Mapping;

/// <summary>
/// Mapping profile for <see cref="Coffee"/> and <see cref="CoffeeDto"/>.
/// </summary>
public sealed class CoffeeProfile : Profile
{
	/// <summary>
	/// Initializes the <see cref="CoffeeProfile"/> class.
	/// </summary>
	public CoffeeProfile()
	{
		base.CreateMap<Coffee, CoffeeDto>();
		base.CreateMap<CoffeeDto, Coffee>();
	}
}
