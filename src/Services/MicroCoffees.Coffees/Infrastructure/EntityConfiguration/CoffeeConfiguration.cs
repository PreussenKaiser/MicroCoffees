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
	/// <summary>
	/// 
	/// </summary>
	private readonly Coffee[] seededCoffees;

	public CoffeeConfiguration()
	{
		this.seededCoffees = new Coffee[12]
		{
			new("Generic Coffee",
				"https://th.bing.com/th/id/OIP.CloEEL0cB_QDXljC3abB5gHaE8?pid=ImgDet&rs=1",
				new CostUsd(7.99m),
				new Quantity(1),
				Roast.Light),

			new("The Breakpoint",
				"https://th.bing.com/th/id/OIP.0ADp4_DH5Lew45ZJCnJe7QHaFg?pid=ImgDet&rs=1",
				new CostUsd(12.99m),
				new Quantity(3),
				Roast.Dark),

			new("Monad Monster",
				"https://th.bing.com/th/id/R.7c4b342409966068c7bb98219985480d?rik=S2kiujZKPRxB0g&riu=http%3a%2f%2f1.bp.blogspot.com%2f-1r-vd0CSMHw%2fThYLo7LSlFI%2fAAAAAAAAEXc%2fqNnSu3O6ofg%2fs1600%2fcoffee9.JPG&ehk=8SFWv%2fVEwHRDPMNZVRKhuQSSsTRK3U0%2fRHlPr5rLEys%3d&risl=&pid=ImgRaw&r=0",
				new CostUsd(9.99m),
				new Quantity(2),
				Roast.Medium),

			new("Null Reference Exception",
				"https://thumbs.dreamstime.com/b/fire-hot-coffee-white-cup-33390113.jpg",
				new CostUsd(0.99m),
				new Quantity(6),
				Roast.Dark),

			new("The Oriental Object",
				"https://thumbs.dreamstime.com/z/coffee-ornate-china-cup-8144721.jpg",
				new CostUsd(14.99m),
				new Quantity(1),
				Roast.Medium),

			new("Function, Oriented",
				"https://th.bing.com/th/id/OIF.sixOhvNquXnii2EqLJhfZw?pid=ImgDet&rs=1",
				new CostUsd(19.99m),
				new Quantity(2),
				Roast.Light),

			new("Integer Overflow",
				"https://c2.staticflickr.com/8/7087/7213400040_8a548668d6_b.jpg",
				new CostUsd(4.99m),
				new Quantity(5),
				Roast.Light),

			new("",
				"",
				new CostUsd(0.00m),
				new Quantity(1),
				Roast.Light),

			new("",
				"",
				new CostUsd(0.00m),
				new Quantity(1),
				Roast.Light),

			new("",
				"",
				new CostUsd(0.00m),
				new Quantity(1),
				Roast.Light),

			new("",
				"",
				new CostUsd(0.00m),
				new Quantity(1),
				Roast.Light),

			new("",
				"",
				new CostUsd(0.00m),
				new Quantity(1),
				Roast.Light),
		};
	}

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
