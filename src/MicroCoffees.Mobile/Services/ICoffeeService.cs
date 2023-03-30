using MicroCoffees.Mobile.Models;

namespace MicroCoffees.Mobile.Services;

public interface ICoffeeService
{
	Task RequestCoffee(Coffee coffee);

	Task<Coffee?> GetDetailsAsync(Guid id);

	Task<IEnumerable<Coffee>> GetPaginatedAsync(int page = 0, int count = 8);

	Task ServeAsync(Guid id);
}
