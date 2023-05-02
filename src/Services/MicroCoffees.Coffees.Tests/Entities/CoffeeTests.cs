using MicroCoffees.Coffees.Domain.Entities.CoffeeAggregate;
using MicroCoffees.Coffees.Domain.ValueObjects;

namespace MicroCoffees.Coffees.Tests.Entities;

/// <summary>
/// Tests for <see cref="Coffee"/>.
/// </summary>
public sealed class CoffeeTests
{
	/// <summary>
	/// Asserts that the coffee's cost updates correctly when it's quantity is mutated.
	/// </summary>
	[Fact]
	public void Cost_Reflects_Quantity()
	{
		Coffee coffee = new(
			"Coffee",
			"https://image.com/weee.jpg",
			new CostUsd(1.00m),
			new Quantity(1),
			default);

		coffee.UpdateQuantity(2);

		Assert.True(coffee.Cost.Value == 16.00m);
	}
}
