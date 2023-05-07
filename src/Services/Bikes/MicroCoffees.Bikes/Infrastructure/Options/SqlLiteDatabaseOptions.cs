namespace MicroCoffees.Bikes.Infrastructure.Options;

/// <summary>
/// Configuration for a SQLite database.
/// </summary>
public sealed record SqlLiteDatabaseOptions
{
	/// <summary>
	/// Gets the SQLite database path.
	/// </summary>
	public required string DbPath { get; init; }
}
