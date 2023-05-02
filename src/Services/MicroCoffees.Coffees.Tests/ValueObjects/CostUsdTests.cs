using MicroCoffees.Coffees.Domain.ValueObjects;

namespace MicroCoffees.Coffees.Tests.ValueObjects;

/// <summary>
/// Tests for <see cref="CostUsd"/>.
/// </summary>
public sealed class CostUsdTests
{
	/// <summary>
	/// Asserts that validation passes when given valid inputs.
	/// </summary>
	/// <param name="amount">A valid amount of USD.</param>
	[Theory]
	[InlineData(0.99)]
	[InlineData(0.099)]
	public void Validation_Success(decimal amount)
	{
		try
		{
			CostUsd cost = new(amount);
		}
		catch (ArgumentException exception)
		{
			Assert.Fail(exception.Message);

			return;
		}

		Assert.True(true);
	}

	/// <summary>
	/// Asserts that validation fails when given invalid costs.
	/// </summary>
	/// <param name="amount">An invalid amount of USD.</param>
	[Theory]
	[InlineData(-0.01)]
	public void Validation_Failure(decimal amount)
	{
		try
		{
			CostUsd cost = new(amount);
		}
		catch (ArgumentException)
		{
			Assert.True(true);

			return;
		}

		Assert.Fail("Validation failed.");
	}
}
