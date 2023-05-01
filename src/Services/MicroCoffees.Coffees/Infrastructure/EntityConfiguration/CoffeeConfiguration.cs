using MicroCoffees.Coffees.Domain.Entities.CoffeeAggregate;
using MicroCoffees.Coffees.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MicroCoffees.Coffees.Infrastructure.EntityConfiguration;

/// <summary>
/// Contains configuration for <see cref="Coffee"/>.
/// </summary>
public sealed class CoffeeConfiguration : IEntityTypeConfiguration<Coffee>
{
	/// <inheritdoc/>
	public void Configure(EntityTypeBuilder<Coffee> builder)
	{
		builder.Ignore(c => c.DomainEvents);

		builder.HasKey(c => c.Id);

		builder
			.Property(c => c.Name)
			.HasMaxLength(32);

		builder
			.Property(c => c.ImageUrl)
			.HasMaxLength(256);

		builder
			.Property(c => c.Cost)
			.HasPrecision(18, 2)
			.HasConversion(
				c => c.Value,
				c => new CostUsd(c));

		builder
			.Property(c => c.Quantity)
			.HasConversion(
				q => q.Value,
				q => new Quantity(q));
	}
}
