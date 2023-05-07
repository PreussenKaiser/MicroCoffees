using MicroCoffees.Bikes.Domain.Entities.Bikes;
using MicroCoffees.Bikes.Infrastructure.Options;
using SQLite;

namespace MicroCoffees.Bikes.Infrastructure.Repositories;

/// <summary>
/// SQLite persistence for <see cref="Bike"/>.
/// </summary>
public sealed class SQLiteBikeRepository : IBikeRepository, IAsyncDisposable
{
	/// <summary>
	/// The connection to the SQLite database.
	/// </summary>
	private readonly SQLiteAsyncConnection connection;

	/// <summary>
	/// Initializes the <see cref="SQLiteBikeRepository"/> class.
	/// </summary>
	/// <param name="options">Configuration options for the SQLite database.</param>
	public SQLiteBikeRepository(SqlLiteDatabaseOptions options)
	{
		this.connection = new SQLiteAsyncConnection(options.DbPath);

		this.connection.CreateTableAsync<Bike>();
	}

	public async Task Add(Bike bike)
	{
		await this.connection.InsertAsync(bike);
	}

	/// <summary>
	/// Closes the SQLite connection.
	/// </summary>
	/// <returns>Whether the task was completed or not.</returns>
	public async ValueTask DisposeAsync()
	{
		await this.connection.CloseAsync();
	}
}
