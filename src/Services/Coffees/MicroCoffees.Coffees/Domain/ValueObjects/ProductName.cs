using System.Text.RegularExpressions;

namespace MicroCoffees.Coffees.Domain.ValueObjects;

/// <summary>
/// Represents the name of a product.
/// </summary>
public sealed record ProductName
{
	/// <summary>
	/// The maximum allowed string length.
	/// </summary>
	public const int MAX_LENGTH = 32;

	/// <summary>
	/// Matches for a string that has no special characters.
	/// </summary>
	public const string REGEX = "^[a-zA-Z0-9 ]+$";

	/// <summary>
	/// Initializes the <see cref="ProductName"/> value object.
	/// </summary>
	/// <param name="value">The product's name.</param>
	/// <exception cref="ArgumentException"></exception>
	public ProductName(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			throw new ArgumentException($"The value {value}, name cannot be empty or null");
		}

		if (value.Length > MAX_LENGTH)
		{
			throw new ArgumentException($"The value '{value}' is invalid, name must be between 1 and 32 characters long.");
		}

		if (!Regex.IsMatch(value, REGEX))
		{
			throw new ArgumentException($"The value '{value}' is invalid, name cannot contain special characters.");
		}

		this.Value = value;
	}

	/// <summary>
	/// Gets the product's name.
	/// </summary>
	public string Value { get; }
}
