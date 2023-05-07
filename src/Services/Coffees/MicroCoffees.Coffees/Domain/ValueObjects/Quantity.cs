namespace MicroCoffees.Coffees.Domain.ValueObjects;

/// <summary>
/// Represents the quantity of an item.
/// </summary>
public sealed record Quantity
{
	/// <summary>
	/// The maximum allowed value.
	/// </summary>
	public const int MAX_VALUE = 8;

	/// <summary>
	/// The minimum allowed value.
	/// </summary>
	public const int MIN_VALUE = 1;

	/// <summary>
	/// Initializes the <see cref="Quantity"/> valeu object
	/// </summary>
	/// <param name="value">The quantity of the item.</param>
	/// <exception cref="ArgumentException"></exception>
	public Quantity(int value)
	{
		this.Value = value >= MIN_VALUE && value <= MAX_VALUE
			? value
			: throw new ArgumentException($"Quantity value must be between {MIN_VALUE} & {MAX_VALUE}.");
	}

	/// <summary>
	/// Gets the quantity of the item.
	/// </summary>
	public int Value { get; }
}
