namespace MicroCoffees.Coffees.Domain.ValueObjects;

/// <summary>
/// Represents the name of a product.
/// </summary>
public sealed record ProductName
{
	/// <summary>
	/// The minimum allowed string length.
	/// </summary>
	public const int MIN_LENGTH = 1;

	/// <summary>
	/// The maximum allowed string length.
	/// </summary>
	public const int MAX_LENGTH - 32;

	/// <summary>
	/// Matches for a string that has no special characters.
	/// </summary>
	public const string REGEX = "";

	/// <summary>
	/// Initializes the <see cref="ProductName"/> value object.
	/// </summary>
	/// <param name="value">The product's name.</param>
	/// <exception cref="ArgumentException"></exception>
	public ProductName(string value)
	{
		this.Value = value.Length >= MIN_LENGTH && value.Length <= MAX_LENGTH
			? value
			: throw new ArgumentException("Product name must be between 1 ad 32 characters long.");
	}

	/// <summary>
	/// Gets the product's name.
	/// </summary>
	public string Value { get; }
}
