using MicroCoffees.Domain.Entities.CoffeeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroCoffees.Api.Infrastructure.EntityConfiguration;

/// <summary>
/// 
/// </summary>
public sealed class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="builder"></param>
	public void Configure(EntityTypeBuilder<Ingredient> builder)
	{
		builder.HasKey(i => i.Id);

		builder.Ignore(i => i.DomainEvents);

		builder.Property(i => i.Name).HasMaxLength(32);
		builder.Property(i => i.Cost).HasPrecision(18, 2);
	}
}
