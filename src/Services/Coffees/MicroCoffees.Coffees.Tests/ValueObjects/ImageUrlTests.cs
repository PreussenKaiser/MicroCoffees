using MicroCoffees.Coffees.Domain.ValueObjects;

namespace MicroCoffees.Coffees.Tests.ValueObjects;

/// <summary>
/// Tests for <see cref="ImageUrl"/>.
/// </summary>
public sealed class ImageUrltests
{
	/// <summary>
	/// Asserts that a valid image url passes validation.
	/// </summary>
	/// <param name="url">A valid image url.</param>
	[Theory]
	[InlineData("http://website.com/images/img.png")]
	[InlineData("https://karllukan.com/Resources/Images/me.jpg")]
	public void Validation_Success(string url)
	{
		try
		{
			ImageUrl imageUrl = new(url);
		}
		catch (ArgumentException)
		{
			Assert.Fail("Validation failed.");

			return;
		}

		Assert.True(true);
	}

	/// <summary>
	/// Asserts that validation fails when given incorrect inputs.
	/// </summary>
	/// <param name="url">An invalid image link.</param>
	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData("foo")]
	[InlineData("bar.jpg")]
	[InlineData(".png")]
	[InlineData("README.md")]
	[InlineData("https://karllukan.com")]
	[InlineData("https://karllukan.com/images/README.md")]
	public void Validation_Failed(string url)
	{
		try
		{
			ImageUrl imageUrl = new(url);
		}
		catch (ArgumentException)
		{
			Assert.True(true);

			return;
		}

		Assert.Fail("Validation failed.");
	}
}
