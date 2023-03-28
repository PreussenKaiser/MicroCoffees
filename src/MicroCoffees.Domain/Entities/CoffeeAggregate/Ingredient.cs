namespace MicroCoffees.Domain.Entities.CoffeeAggregate;

/// <summary>
/// Represents an ingredient in <see cref="Coffee"/>.
/// </summary>
public sealed class Ingredient : Entity
{
	/// <summary>
	/// Initializes the <see cref="Ingredient"/> class.
	/// </summary>
	public Ingredient() : base()
	{
		this.Name ??= string.Empty;
	}

	public Ingredient(string name, decimal cost)
		: this()
	{
		this.Name = name;
		this.Cost = cost;
	}

	/// <summary>
	/// The ingredient's name.
	/// </summary>
	public string Name { get; private set; }

	/// <summary>
	/// How much the ingredient costs in USD.
	/// </summary>
	public decimal Cost { get; private set; }
}
