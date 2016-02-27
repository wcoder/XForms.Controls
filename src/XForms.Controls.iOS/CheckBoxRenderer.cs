using System.ComponentModel;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XForms.Controls;
using XForms.Controls.iOS;
using XForms.Controls.iOS.Views;

[assembly: ExportRenderer(typeof(CheckBox), typeof(CheckBoxRenderer))]

namespace XForms.Controls.iOS
{
	using CheckBox = XForms.Controls.CheckBox;

	public class CheckBoxRenderer : ViewRenderer<CheckBox, CheckBoxView>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<CheckBox> e)
		{
			base.OnElementChanged(e);

			BackgroundColor = Element.BackgroundColor.ToUIColor();

			if (Control == null)
			{
				var checkBox = new CheckBoxView(Bounds);
				checkBox.TouchUpInside += (s, args) => Element.Checked = Control.Checked;

				SetNativeControl(checkBox);
			}

			UpdateFont();

			Control.LineBreakMode = UILineBreakMode.CharacterWrap;
			Control.VerticalAlignment = UIControlContentVerticalAlignment.Top;
			Control.CheckedTitle = string.IsNullOrEmpty(e.NewElement.CheckedText) ? e.NewElement.DefaultText : e.NewElement.CheckedText;
			Control.UncheckedTitle = string.IsNullOrEmpty(e.NewElement.UncheckedText) ? e.NewElement.DefaultText : e.NewElement.UncheckedText;
			Control.Checked = e.NewElement.Checked;
			Control.SetTitleColor(e.NewElement.TextColor.ToUIColor(), UIControlState.Normal);
			Control.SetTitleColor(e.NewElement.TextColor.ToUIColor(), UIControlState.Selected);
		}

		//private void ResizeText()
		//{
		//	var text = Element.Checked ? string.IsNullOrEmpty(Element.CheckedText) ? Element.DefaultText : Element.CheckedText :
		//		string.IsNullOrEmpty(Element.UncheckedText) ? Element.DefaultText : Element.UncheckedText;

		//	var bounds = Control.Bounds;

		//	var width = Control.TitleLabel.Bounds.Width;

		//	var height = text.StringHeight(Control.Font, width);

		//	var minHeight = string.Empty.StringHeight(Control.Font, width);

		//	var requiredLines = Math.Round((decimal)(height / minHeight), MidpointRounding.AwayFromZero);

		//	var supportedLines = Math.Round(bounds.Height / minHeight, MidpointRounding.ToEven);

		//	if (supportedLines != (double)requiredLines)
		//	{
		//		bounds.Height += (float)(minHeight * (requiredLines - (decimal)supportedLines));
		//		Control.Bounds = bounds;
		//		Element.HeightRequest = bounds.Height;
		//	}
		//}

		//public override void Draw(CGRect rect)
		//{
		//	base.Draw(rect);
		//	ResizeText();
		//}

		private void UpdateFont()
		{
			if (string.IsNullOrEmpty(Element.FontName))
			{
				return;
			}

			var font = UIFont.FromName(Element.FontName, (Element.FontSize > 0) ? (float)Element.FontSize : 12.0f);

			if (font != null)
			{
				Control.Font = font;
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			switch (e.PropertyName)
			{
				case "Checked":
					Control.Checked = Element.Checked;
					break;
				case "TextColor":
					Control.SetTitleColor(Element.TextColor.ToUIColor(), UIControlState.Normal);
					Control.SetTitleColor(Element.TextColor.ToUIColor(), UIControlState.Selected);
					break;
				case "CheckedText":
					Control.CheckedTitle = string.IsNullOrEmpty(Element.CheckedText) ? Element.DefaultText : Element.CheckedText;
					break;
				case "UncheckedText":
					Control.UncheckedTitle = string.IsNullOrEmpty(Element.UncheckedText) ? Element.DefaultText : Element.UncheckedText;
					break;
				case "FontSize":
					UpdateFont();
					break;
				case "FontName":
					UpdateFont();
					break;
				case "Element":
					break;
				default:
					System.Diagnostics.Debug.WriteLine("Property change for {0} has not been implemented.", e.PropertyName);
					return;
			}
		}
	}
}
