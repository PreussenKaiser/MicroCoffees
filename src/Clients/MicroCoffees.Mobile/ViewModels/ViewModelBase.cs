using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MicroCoffees.Mobile.ViewModels;

/// <summary>
/// Represemts a view model.
/// </summary>
internal abstract class ViewModelBase : INotifyPropertyChanged
{
	/// <summary>
	/// 
	/// </summary>
	public event PropertyChangedEventHandler? PropertyChanged;

	/// <summary>
	/// 
	/// </summary>
	/// <param name="propertyName"></param>
	protected void OnPropertyChanged(
		[CallerMemberName] string propertyName = "")
	{
		this.PropertyChanged?.Invoke(
			this, new PropertyChangedEventArgs(propertyName));
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="backingField"></param>
	/// <param name="value"></param>
	/// <param name="propertyName"></param>
	protected void SetProperty<T>(
		ref T backingField, T value,
		[CallerMemberName] string propertyName = "")
	{
		backingField = value;

		this.OnPropertyChanged(propertyName);
	}
}
