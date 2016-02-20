using Android.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XForms.Controls;
using XForms.Controls.Droid;

[assembly: ExportRenderer(typeof(NumberEntry), typeof(NumberEntryRenderer))]
namespace XForms.Controls.Droid
{
	public class NumberEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				Control.InputType = InputTypes.ClassNumber;
			}
		}
	}
}