namespace MicroCoffees.Coffees.Domain.Persistence;

/// <summary>
/// Implements a unit of work.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Persists changes in the database.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>Rows affected by the update.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
