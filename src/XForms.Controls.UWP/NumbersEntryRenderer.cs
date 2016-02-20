using Windows.UI.Xaml.Input;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using XForms.Controls;
using XForms.Controls.UWP;

[assembly: ExportRenderer(typeof(NumberEntry), typeof(NumbersEntryRenderer))]
namespace XForms.Controls.UWP
{
	public class NumbersEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement == null)
			{
				var control = (FormsTextBox)Control;
				InputScope inputScope = new InputScope();
				InputScopeName inputScopeName = new InputScopeName();

				inputScopeName.NameValue = InputScopeNameValue.Digits;
				inputScope.Names.Add(inputScopeName);
				control.InputScope = inputScope;
			}
		}
	}
}
