using MicroCoffees.Domain.Events;

namespace MicroCoffees.Domain.Entities.CoffeeAggregate;

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
		decimal cost,
		int quantity,
		Roast roast) : this()
	{
		this.Name = name;
		this.ImageUrl = imageUrl;
		this.Cost = cost;
		this.Quantity = quantity > 0 ? quantity : 1;
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
	public decimal Cost { get; private set; }

	/// <summary>
	/// How much of this <see cref="Coffee"/> the shop has in stock.
	/// </summary>
	public int Quantity { get; private set; }

	/// <summary>
	/// The coffee's roast type.
	/// </summary>
	public Roast Roast { get; private set; }

	/// <summary>
	/// Serves the <see cref="Coffee"/> to a customer.
	/// </summary>
	/// <exception cref="InvalidOperationException"></exception>
	public void Serve()
	{
		if (this.Quantity <= 0)
		{
			throw new InvalidOperationException("Cannot serve a coffee that we don't have.");
		}

		this.Quantity--;

		if (this.Quantity == 0)
		{
			base.AddEvent(new RemoveCoffeeEvent(this));
		}
	}
}
