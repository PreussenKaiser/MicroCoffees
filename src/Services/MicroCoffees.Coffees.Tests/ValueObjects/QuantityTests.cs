using MicroCoffees.Coffees.Domain.ValueObjects;

namespace MicroCoffees.Coffees.Tests.ValueObjects;

/// <summary>
/// Tests for <see cref="Quantity"/>.
/// </summary>
public sealed class QuantityTests
{
	/// <summary>
	/// Asserts that validation passes when given valid inputs.
	/// </summary>
	/// <param name="amount">A valid quantity.</param>
	[Theory]
	[InlineData(1)]
	[InlineData(4)]
	[InlineData(8)]
	public void Validation_Success(int amount)
	{
		try
		{
			Quantity quantity = new(amount);
		}
		catch (ArgumentException)
		{
			Assert.Fail("Validation failed");

			return;
		}

		Assert.True(true);
	}

	/// <summary>
	/// Asserts that validation fails when given invalid inputs.
	/// </summary>
	/// <param name="amount">An invalid quantity.</param>
	[Theory]
	[InlineData(0)]
	[InlineData(9)]
	public void Validation_Failure(int amount)
	{
		try
		{
			Quantity quantity = new(amount);
		}
		catch (ArgumentException)
		{
			Assert.True(true);

			return;
		}

		Assert.Fail("Validation failed.");
	}
}
