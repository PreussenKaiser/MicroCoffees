namespace MicroCoffees.Domain.Entities;

public sealed record Quantity
{
	public Quantity(int quantity)
	{
		this.Value = quantity > 0 ? quantity : 1;
	}

	public int Value { get; private set; }

	public static implicit operator int(Quantity quantity)
		=> quantity.Value;

	public static explicit operator int(Quantity quantity)
		=> quantity.Value;
}
