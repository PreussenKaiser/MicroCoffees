using System.ComponentModel.DataAnnotations;

namespace MicroCoffees.Mobile.Models;

/// <summary>
/// Data model for a coffee.
/// </summary>
public sealed class Coffee
{
	/// <summary>
	/// Initializes the <see cref="Coffee"/> class.
	/// </summary>
	public Coffee()
	{
		this.Id = Guid.NewGuid();
		this.Name = string.Empty;
		this.ImageUrl = string.Empty;
		this.Count = 1;
	}

	/// <summary>
	/// The coffee's unique identifier.
	/// </summary>
	public Guid Id { get; set; }

	/// <summary>
	/// The coffee's name.
	/// </summary>
	[Required]
	[MaxLength(32, ErrorMessage = "Name cannot be more than 32 characters long.")]
	public string Name { get; set; }

	/// <summary>
	/// A url leading to an image of the coffee.
	/// </summary>
	[Display(Name = "Image")]
	[Required]
	[MaxLength(256, ErrorMessage = "Image file must have less than 256 characters.")]
	public string ImageUrl { get; set; }

	/// <summary>
	/// The coffee's cost.
	/// </summary>
	[Required]
	public decimal Cost
		=> (this.Count * 8) + (decimal)this.Roast;

	/// <summary>
	/// The coffee's quantity.
	/// </summary>
	[Required]
	[Range(1, int.MaxValue)]
	public int Count { get; set; }

	public Roast Roast { get; set; }
}
