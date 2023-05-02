using MicroCoffees.Mobile.Models;
using System.Net.Http.Json;

namespace MicroCoffees.Mobile.Services;

/// <summary>
/// Executes queries and commands against a coffees API.
/// </summary>
public sealed class CoffeeService : ICoffeeService
{
	/// <summary>
	/// The client to send requests with.
	/// </summary>
	private readonly HttpClient client;

	/// <summary>
	/// Initializes the <see cref="CoffeeService"/> class.
	/// </summary>
	/// <param name="factory">Initializes the correct <see cref="HttpClient"/>.</param>
	public CoffeeService(IHttpClientFactory factory)
	{
		this.client = factory.CreateClient("coffees");
	}

	/// <inheritdoc/>
	public async Task RequestCoffee(Coffee coffee)
	{
		await this.client.PostAsJsonAsync(string.Empty, coffee);
	}

	/// <inheritdoc/>
	public async Task<Coffee?> FindAsync(Guid id)
	{
		var coffee = await this.client.GetFromJsonAsync<Coffee>(id.ToString());

		return coffee;
	}

	/// <inheritdoc/>
	public async Task<IEnumerable<Coffee>> SearchAsync(int page = 0, int count = 8)
	{
		var coffees = await this.client.GetFromJsonAsync<IEnumerable<Coffee>>(
			$"page/{page}/count/{count}");

		return coffees ?? Enumerable.Empty<Coffee>();
	}

	/// <inheritdoc/>
	public async Task UpdateQuantityAsync(Guid id, int qty)
	{
		HttpRequestMessage request = new(
			HttpMethod.Patch, $"{id}/qty/{qty}");

		await this.client.SendAsync(request);
	}

	/// <inheritdoc/>
	public async Task CancelAsync(Guid id)
	{
		await this.client.DeleteAsync(id.ToString());
	}
}
