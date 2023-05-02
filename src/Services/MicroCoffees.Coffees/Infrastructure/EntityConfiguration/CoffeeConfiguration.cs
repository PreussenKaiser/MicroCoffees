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
	/// Coffees to seed.
	/// </summary>
	private readonly Coffee[] seededCoffees;

	/// <summary>
	/// Initializes the <see cref="CoffeeConfiguration"/> class,
	/// </summary>
	public CoffeeConfiguration()
	{
		this.seededCoffees = new Coffee[12]
		{
			new("Generic Coffee",
				"https://news.usc.edu/files/2016/04/20140425_Coffee_web.jpg",
				new CostUsd(7.99m),
				new Quantity(1),
				Roast.Light),

			new("The Breakpoint",
				"https://cdn.wallpapersafari.com/18/52/4lg2Ow.jpg",
				new CostUsd(12.99m),
				new Quantity(3),
				Roast.Dark),

			new("Monad Monster",
				"https://thecoffeevine.com/wp-content/uploads/2013/05/img_4869-500x375.jpg",
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

			new("Funk Oriented",
				"https://i.pinimg.com/736x/7d/5e/d8/7d5ed89982c309ac9bd993e5b0e70e15.jpg",
				new CostUsd(19.99m),
				new Quantity(2),
				Roast.Light),

			new("Integer Overflow",
				"https://c2.staticflickr.com/8/7087/7213400040_8a548668d6_b.jpg",
				new CostUsd(4.99m),
				new Quantity(5),
				Roast.Light),

			new("Line Three",
				"https://bestcoffeespan.com/wp-content/uploads/2021/01/aged-coffee-scaled.jpg",
				new CostUsd(31.99m),
				new Quantity(3),
				Roast.Light),

			new("AbstractCoffeeFactorySingleton",
				"https://i.pinimg.com/originals/dd/af/b5/ddafb54b7c1544f34236017df5928f0b.jpg",
				new CostUsd(2.99m),
				new Quantity(2),
				Roast.Medium),

			new("Imposter Syndrome",
				"https://fastly.4sqi.net/img/general/600x600/PMT3R1OBRPE45IPDSSYF1XCIGM3QN10JPT1N5RI0DV1CBJG4.jpg",
				new CostUsd(99.99m),
				new Quantity(1),
				Roast.Dark),

			new("10x Coffee",
				"https://farm6.staticflickr.com/5254/5438241040_b85e8556ff_n.jpg",
				new CostUsd(9.99m),
				new Quantity(1),
				Roast.Light),

			new("Eight Bitter",
				"https://eadn-wc04-202503.nxedge.io/cdn/wp-content/uploads/2013/03/coffee-clay-cup.jpg",
				new CostUsd(7.99m),
				new Quantity(8),
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
			.HasConversion(
				n => n.Value,
				n => new ProductName(n))
			.HasMaxLength(ProductName.MAX_LENGTH);

		builder
			.Property(c => c.ImageUrl)
			.HasConversion(
				i => i.Value,
				i => new ImageUrl(i))
			.HasMaxLength(ImageUrl.MAX_LENGTH);

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

		builder.HasData(this.seededCoffees);
	}
}
