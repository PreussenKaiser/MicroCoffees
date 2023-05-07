using System.Text.RegularExpressions;

namespace MicroCoffees.Coffees.Domain.ValueObjects;

/// <summary>
/// Represents a link to an image on the web.
/// </summary>
public sealed record ImageUrl
{
	/// <summary>
	/// The maximum string value.
	/// </summary>
	public const int MAX_LENGTH = 256;

	/// <summary>
	/// Matches against a valid image url.
	/// </summary>
	public const string REGEX = "^(http(s?):)([/|.|\\w|\\s|-])*\\.(?:jpg|gif|png)$";

	/// <summary>
	/// Initializes the <see cref="ImageUrl"/> value object.
	/// </summary>
	/// <param name="value">A link to an image.</param>
	/// <exception cref="ArgumentException"></exception>
	public ImageUrl(string value)
	{
		this.Value = 
			value is not null &&
			value.Length <= MAX_LENGTH &&
			Regex.IsMatch(value, REGEX)
				? value
				: throw new ArgumentException($"{value} is an invalid.");
	}

	/// <summary>
	/// Gets a link to an image.
	/// </summary>
	public string Value { get; }
}
