using Xamarin.Forms;

namespace XFormsControls.Templates
{
	public class MainItemTemplate : ContentView
	{
		public MainItemTemplate()
		{
			var label = new Label
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center
			};
			label.SetBinding(Label.TextProperty, "Name");

			Content = label;
		}
	}
}
