using Windows.UI;
using Windows.UI.Xaml.Media;

namespace XForms.Controls.UWP.Helpers
{
	public static class ValueConverters
	{
		public static FontFamily StringToFontFamily(string fontfamilyName)
		{
			return new FontFamily(fontfamilyName);
		}

		public static Color FormsColorToNative(Xamarin.Forms.Color color)
		{
			return Color.FromArgb(
				(byte)color.A,
				(byte)color.R,
				(byte)color.G,
				(byte)color.B);
		}
	}
}
