using System;
using Xamarin.Forms;

namespace XForms.Controls
{
	public class CheckBox : View
	{
		public static readonly BindableProperty CheckedProperty =
			BindableProperty.Create<CheckBox, bool>(
				p => p.Checked, false);

		public static readonly BindableProperty CheckedTextProperty =
			BindableProperty.Create<CheckBox, string>(
				p => p.CheckedText, string.Empty, BindingMode.TwoWay);

		public static readonly BindableProperty UncheckedTextProperty =
			BindableProperty.Create<CheckBox, string>(
				p => p.UncheckedText, string.Empty);

		public static readonly BindableProperty DefaultTextProperty =
			BindableProperty.Create<CheckBox, string>(
				p => p.Text, string.Empty);

		public static readonly BindableProperty TextColorProperty =
			BindableProperty.Create<CheckBox, Color>(
				p => p.TextColor, Color.Black);

		public static readonly BindableProperty FontSizeProperty =
			BindableProperty.Create<CheckBox, double>(
				p => p.FontSize, -1);

		public static readonly BindableProperty FontNameProperty =
			BindableProperty.Create<CheckBox, string>(
				p => p.FontName, string.Empty);


		public EventHandler<bool> CheckedChanged;


		public bool Checked
		{
			get { return (bool)GetValue(CheckedProperty); }
			set
			{
				SetValue(CheckedProperty, value);
				if (CheckedChanged != null)
					CheckedChanged.Invoke(this, value);
			}
		}

		public string CheckedText
		{
			get { return (string)GetValue(CheckedTextProperty); }
			set { SetValue(CheckedTextProperty, value); }
		}

		public string UncheckedText
		{
			get { return (string)GetValue(UncheckedTextProperty); }
			set { SetValue(UncheckedTextProperty, value); }
		}

		public string DefaultText
		{
			get { return (string)GetValue(DefaultTextProperty); }
			set { SetValue(DefaultTextProperty, value); }
		}

		public Color TextColor
		{
			get { return (Color)GetValue(TextColorProperty); }
			set { SetValue(TextColorProperty, value); }
		}

		public double FontSize
		{
			get { return (double)GetValue(FontSizeProperty); }
			set { SetValue(FontSizeProperty, value); }
		}

		public string FontName
		{
			get { return (string)GetValue(FontNameProperty); }
			set { SetValue(FontNameProperty, value); }
		}

		public string Text
		{
			get
			{
				return Checked
					? (string.IsNullOrEmpty(CheckedText) ? DefaultText : CheckedText)
						: (string.IsNullOrEmpty(UncheckedText) ? DefaultText : UncheckedText);
			}
		}
	}
}
