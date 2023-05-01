using MicroCoffees.Coffees.Domain.ValueObjects;

namespace MicroCoffees.Coffees.Domain.Entities.CoffeeAggregate;

/// <summary>
/// Represents a coffee sold by the shop.
/// </summary>
public sealed class Coffee : Entity
{
	/// <summary>
	/// Initializes the <see cref="Coffee"/> class.
	/// </summary>
	public Coffee() : base()
	{
		this.Name ??= string.Empty;
		this.ImageUrl ??=  string.Empty;
		this.Cost = new CostUsd(0);
		this.Quantity = new Quantity(1);
	}

	/// <summary>
	/// Initializes the <see cref="Coffee"/> class.
	/// </summary>
	/// <param name="name">The coffee's name.</param>
	/// <param name="imageUrl">A url leading to and image of the coffee.</param>
	/// <param name="cost">The coffee's cost.</param>
	/// <param name="quantity">How much of the coffee we have.</param>
	public Coffee(
		string name,
		string imageUrl,
		CostUsd cost,
		Quantity quantity,
		Roast roast) : this()
	{
		this.Name = name;
		this.ImageUrl = imageUrl;
		this.Cost = cost;
		this.Quantity = quantity;
		this.Roast = roast;
	}

	/// <summary>
	/// The coffee's name.
	/// </summary>
	public string Name { get; private set; }

	/// <summary>
	/// A url leading to an image of the coffee.
	/// </summary>
	public string ImageUrl { get; private set; }

	/// <summary>
	/// The coffee's cost.
	/// </summary>
	public CostUsd Cost { get; private set; }

	/// <summary>
	/// How much of this <see cref="Coffee"/> the shop has in stock.
	/// </summary>
	public Quantity Quantity { get; private set; }

	/// <summary>
	/// The coffee's roast type.
	/// </summary>
	public Roast Roast { get; private set; }

	/// <summary>
	/// Updates the coffee's quantity.
	/// </summary>
	/// <param name="qty">The quantity to set.</param>
	/// <returns>Updated instance.</returns>
	public Coffee UpdateQuantity(int qty)
	{
		this.Quantity = new Quantity(qty);

		this.Cost = new CostUsd((qty * Quantity.MAX_VALUE) + (int)this.Roast);

		return this;
	}
}
