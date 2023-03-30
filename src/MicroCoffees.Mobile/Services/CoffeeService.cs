using MicroCoffees.Mobile.Models;
using System.Net.Http.Json;

namespace MicroCoffees.Mobile.Services;

public sealed class CoffeeService : ICoffeeService
{
	private readonly HttpClient client;

	public CoffeeService(IHttpClientFactory factory)
	{
		this.client = factory.CreateClient("coffees");
	}

	public async Task RequestCoffee(Coffee coffee)
	{
		await this.client.PostAsJsonAsync(string.Empty, coffee);
	}

	public async Task<Coffee?> GetDetailsAsync(Guid id)
	{
		var coffee = await this.client.GetFromJsonAsync<Coffee>(id.ToString());

		return coffee;
	}

	public async Task<IEnumerable<Coffee>> GetPaginatedAsync(int page = 0, int count = 8)
	{
		var coffees = await this.client.GetFromJsonAsync<IEnumerable<Coffee>>(
			$"page/{page}/count/{count}");

		return coffees ?? Enumerable.Empty<Coffee>();
	}

	public async Task ServeAsync(Guid id)
	{
		await this.client.PutAsJsonAsync("serve/", id.ToString());
	}
}
