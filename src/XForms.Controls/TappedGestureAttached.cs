using System.Windows.Input;
using Xamarin.Forms;

namespace XForms.Controls
{
	/// <summary>
	/// Author: Michael Ridland
	/// http://www.michaelridland.com/xamarin/xaml-attached-properties-tricks-in-xamarin-forms/
	/// </summary>
	public class TappedGestureAttached
	{
		public static readonly BindableProperty CommandProperty =
			BindableProperty.CreateAttached(
				propertyName: "Command",
				returnType: typeof(ICommand),
				declaringType: typeof(View),
				defaultValue: null,
				defaultBindingMode: BindingMode.OneWay,
				validateValue: null,
				propertyChanged: OnPropertyChanged);

		public static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			var control = bindable as View;
			if (control != null)
			{
				control.GestureRecognizers.Clear();
				control.GestureRecognizers.Add(new TapGestureRecognizer
				{
					Command = new Command(o =>
					{
						var command = GetItemTapped(control);
						if (command != null && command.CanExecute(null))
						{
							command.Execute(null);
						}
					})
				});
			}
		}

		public static ICommand GetItemTapped(BindableObject bindable)
		{
			return (ICommand)bindable.GetValue(CommandProperty);
		}
	}
}
