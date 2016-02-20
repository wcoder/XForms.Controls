using Windows.UI.Xaml.Input;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinRT;
using XForms.Controls;
using XForms.Controls.WinPhone81;

[assembly: ExportRenderer(typeof(NumberEntry), typeof(NumbersEntryRenderer))]
namespace XForms.Controls.WinPhone81
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

				inputScopeName.NameValue = InputScopeNameValue.Number;
				inputScope.Names.Add(inputScopeName);
				control.InputScope = inputScope;
			}
		}
	}
}
