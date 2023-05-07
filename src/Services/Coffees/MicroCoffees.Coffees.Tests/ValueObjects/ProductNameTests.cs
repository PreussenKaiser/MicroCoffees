using MicroCoffees.Coffees.Domain.ValueObjects;

namespace MicroCoffees.Coffees.Tests.ValueObjects;

/// <summary>
/// Tests for <see cref="ProductName"/>.
/// </summary>
public sealed class ProductNameTests
{
	/// <summary>
	/// Asserts that validation passes when given valid inputs.
	/// </summary>
	/// <param name="name">A valid input.</param>
	[Theory]
	[InlineData("Foo")]
	[InlineData("Foo bar")]
	[InlineData("123")]
	public void Validation_Success(string name)
	{
		try
		{
			ProductName productName = new(name);
		}
		catch (ArgumentException)
		{
			Assert.Fail("Validation failed.");

			return;
		}

		Assert.True(true);
	}

	/// <summary>
	/// Asserts that incorrect inputs results in an exception being thrown.
	/// </summary>
	/// <param name="name">The name which fails validation.</param>
	[Theory]
	[InlineData(null)]
	[InlineData("")]
	[InlineData("/*")]
	[InlineData("This string is over 32 characters long")]
	public void Validation_Fail(string name)
	{
		try
		{
			ProductName productName = new(name);
		}
		catch (ArgumentException)
		{
			Assert.True(true);

			return;
		}

		Assert.Fail("Validation failed.");
	}
}
