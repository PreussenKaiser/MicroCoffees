using AutoMapper;
using MicroCoffees.Api.Application.DTOs;
using MicroCoffees.Domain.Entities.CoffeeAggregate;

namespace MicroCoffees.Api.Application.Mapping;

public sealed class CoffeeProfile : Profile
{
	public CoffeeProfile()
	{
		base.CreateMap<Coffee, CoffeeDto>();
		base.CreateMap<Ingredient, IngredientDto>();

		base.CreateMap<CoffeeDto, Coffee>();
		base.CreateMap<IngredientDto, Ingredient>();
	}
}
