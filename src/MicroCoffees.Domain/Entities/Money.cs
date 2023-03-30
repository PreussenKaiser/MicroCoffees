namespace MicroCoffees.Domain.Entities;

public sealed record Money
{
	public Money(decimal amount)
	{
		this.USD = amount >= 0 ? amount : 0;
	}

	public decimal USD { get; private set; }

	public static implicit operator int(Money money)
		=> money.USD;

	public static explicit operator int(Money money)
		=> money.USD;
}
