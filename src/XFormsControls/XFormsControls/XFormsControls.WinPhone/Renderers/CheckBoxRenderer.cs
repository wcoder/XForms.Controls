using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
using XFormsControls.WinPhone.Renderers;

[assembly: ExportRenderer(typeof(XFormsControls.Controls.CheckBox), typeof(CheckBoxRenderer))]

namespace XFormsControls.WinPhone.Renderers
{
	using NativeCheckBox = CheckBox;

	public class CheckBoxRenderer : ViewRenderer<Controls.CheckBox, CheckBox>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Controls.CheckBox> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
				var checkBox = new NativeCheckBox();
				checkBox.Checked += (s, args) => Element.Checked = true;
				checkBox.Unchecked += (s, args) => Element.Checked = false;
				checkBox.Content = e.NewElement.DefaultText;

				SetNativeControl(checkBox);

				if (Control != null)
				{
					//Control.Content = e.NewElement.DefaultText;
					Control.IsChecked = e.NewElement.Checked;
					//Control.Foreground = ConvertToBrush(e.NewElement.TextColor);
					//UpdateFont();
				}

				Element.CheckedChanged += CheckedChanged;
				Element.PropertyChanged += ElementOnPropertyChanged;
			}

			/*if (e.OldElement != null)
			{
				e.OldElement.CheckedChanged -= CheckedChanged;
			}

			if (Control == null)
			{
				var checkBox = new NativeCheckBox();
				checkBox.Checked += (s, args) => Element.Checked = true;
				checkBox.Unchecked += (s, args) => Element.Checked = false;

				SetNativeControl(checkBox);
			}

			Control.Content = e.NewElement.Text;
			Control.IsChecked = e.NewElement.Checked;
			Control.Foreground = ConvertToBrush(e.NewElement.TextColor);


			UpdateFont();

			Element.CheckedChanged += CheckedChanged;
			Element.PropertyChanged += ElementOnPropertyChanged;*/
		}


		private void ElementOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
		{
			switch (propertyChangedEventArgs.PropertyName)
			{
				case "Checked":
					Control.IsChecked = Element.Checked;
					break;
				/*case "TextColor":
					Control.Foreground = ConvertToBrush(Element.TextColor);
					break;
				case "FontName":
				case "FontSize":
					UpdateFont();
					break;*/
				case "CheckedText":
				case "UncheckedText":
					Control.Content = Element.Text;
					break;
				default:
					Debug.WriteLine("Property change for {0} has not been implemented.", propertyChangedEventArgs.PropertyName);
					break;
			}
		}


		private void CheckedChanged(object sender, bool e)
		{
			Device.BeginInvokeOnMainThread(() =>
			{
				Control.Content = Element.Text;
				Control.IsChecked = e;
			});
		}

		/*private void CheckedChanged(object sender, EventArgs<bool> eventArgs)
		{
			
		}*/

		/*private void UpdateFont()
		{
			if (!string.IsNullOrEmpty(Element.FontName))
			{
				Control.FontFamily = new FontFamily(Element.FontName);
			}

			Control.FontSize = (Element.FontSize > 0) ? (float) Element.FontSize : 12.0f;
		}*/


		/*private Brush ConvertToBrush(Color color)
		{
			return new SolidColorBrush(
				System.Windows.Media.Color.FromArgb(
					(byte) color.A,
					(byte) color.R,
					(byte) color.G,
					(byte) color.B));
		}*/
	}
}
