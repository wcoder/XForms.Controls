using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XForms.Controls;
using XForms.Controls.iOS;

[assembly: ExportRenderer(typeof(NumberEntry), typeof(NumberEntryRenderer))]
namespace XForms.Controls.iOS
{
	public class NumberEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.KeyboardType = UIKeyboardType.NumberPad;
			}
		}
	}
}
