namespace MicroCoffees.Coffees.Domain.ValueObjects;
/// <summary>
/// Represents the cost of something in USD.
/// </summary>
public sealed record CostUsd
{
	/// <summary>
	/// The minimum cost of an item.
	/// </summary>
	public const decimal MIN_VALUE = 0.00m;

	/// <summary>
	/// Initializes the <see cref="CostUsd"/> value object.
	/// </summary>
	/// <param name="value">The cost of the item.</param>
	/// <exception cref="ArgumentException"></exception>
	public CostUsd(decimal value)
	{
		this.Value = value >= MIN_VALUE
			? decimal.Round(value, 2)
			: throw new ArgumentException("Cost cannot be negative.");
	}

	/// <summary>
	/// Gets the cost of the item.
	/// </summary>
	public decimal Value { get; }

	/// <inheritdoc/>
	public override string ToString()
	{
		return $"${this.Value}";
	}
}
