using MicroCoffees.Domain.Entities.CoffeeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroCoffees.Api.Infrastructure.EntityConfiguration;

/// <summary>
/// 
/// </summary>
public sealed class CoffeeConfiguration : IEntityTypeConfiguration<Coffee>
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="builder"></param>
	public void Configure(EntityTypeBuilder<Coffee> builder)
	{
		builder.HasKey(c => c.Id);

		builder.Property(c => c.Name).HasMaxLength(32);
		builder.Property(c => c.ImageUrl).HasMaxLength(256);
		builder.Property(c => c.Cost).HasPrecision(18, 2);

		builder.Metadata
			.FindNavigation(nameof(Coffee.Ingredients))
			?.SetPropertyAccessMode(PropertyAccessMode.Field);

		builder.Ignore(c => c.DomainEvents);
	}
}
