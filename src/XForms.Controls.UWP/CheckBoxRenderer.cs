using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;
using XForms.Controls;
using XForms.Controls.UWP;
using XForms.Controls.UWP.Helpers;

[assembly: ExportRenderer(typeof(CheckBox), typeof(CheckBoxRenderer))]

namespace XForms.Controls.UWP
{
	using NativeCheckBox = Windows.UI.Xaml.Controls.CheckBox;

	public class CheckBoxRenderer : ViewRenderer<CheckBox, NativeCheckBox>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<CheckBox> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null)
			{
				e.OldElement.PropertyChanged -= ElementOnPropertyChanged;
			}

			if (Control == null)
			{
				var checkBox = new NativeCheckBox();
				checkBox.Checked += checkBox_Checked;
				checkBox.Unchecked += checkBox_Unchecked;

				SetNativeControl(checkBox);
			}

			Control.IsChecked = e.NewElement.Checked;

			Control.Foreground = new SolidColorBrush(ValueConverters.FormsColorToNative(e.NewElement.TextColor));

			if (e.NewElement.FontSize > 0)
			{
				Control.FontSize = (float)e.NewElement.FontSize;
			}

			if (!string.IsNullOrEmpty(e.NewElement.FontName))
			{
				Control.FontFamily = ValueConverters.StringToFontFamily(e.NewElement.FontName);
			}

			Element.CheckedChanged += CheckedChanged;
			Element.PropertyChanged += ElementOnPropertyChanged;
		}

		private void CheckedChanged(object sender, bool e)
		{
			Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
			{
				Control.IsChecked = e;
			});
		}

		private void checkBox_Checked(object sender, RoutedEventArgs e)
		{
			Element.Checked = true;
		}

		private void checkBox_Unchecked(object sender, RoutedEventArgs e)
		{
			Element.Checked = false;
		}

		private void ElementOnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case "Checked":
					Control.IsChecked = Element.Checked;
					break;
				case "TextColor":
					Control.Foreground = new SolidColorBrush(ValueConverters.FormsColorToNative(Element.TextColor));
					break;
				case "FontName":
					if (!string.IsNullOrEmpty(Element.FontName))
					{
						Control.FontFamily = ValueConverters.StringToFontFamily(Element.FontName);
					}
					break;
				case "FontSize":
					if (Element.FontSize > 0)
					{
						Control.FontSize = (float)Element.FontSize;
					}
					break;
				case "CheckedText":
				case "UncheckedText":
					break;
				default:
					System.Diagnostics.Debug.WriteLine("Property change for {0} has not been implemented.", e.PropertyName);
					break;
			}
		}
	}
}
