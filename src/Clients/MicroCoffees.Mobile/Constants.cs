namespace MicroCoffees.Mobile;

/// <summary>
/// Contains application constants.
/// </summary>
internal static class Constants
{
	/// <summary>
	/// Url for the coffees API.
	/// </summary>
	internal static readonly string CoffeesUrl;

	/// <summary>
	/// Initializes the <see cref="Constants"/> class.
	/// </summary>
	static Constants()
	{
		string urlBase = DeviceInfo.Platform == DevicePlatform.Android
			? "http://10.0.2.2"
			: "http://localhost";

		CoffeesUrl = $"{urlBase}:5000/api/coffees/";
	}
}
