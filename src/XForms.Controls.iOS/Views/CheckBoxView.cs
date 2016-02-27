using CoreGraphics;
using Foundation;
using UIKit;

namespace XForms.Controls.iOS.Views
{
	[Register("CheckBoxView")]
	public class CheckBoxView : UIButton
	{
		public CheckBoxView()
		{
			Initialize();
		}

		public CheckBoxView(CGRect bounds)
			: base(bounds)
		{
			Initialize();
		}

		public string CheckedTitle
		{
			set
			{
				SetTitle(value, UIControlState.Selected);
			}
		}

		public string UncheckedTitle
		{
			set
			{
				SetTitle(value, UIControlState.Normal);
			}
		}

		public bool Checked
		{
			set { Selected = value; }
			get { return Selected; }
		}

		void Initialize()
		{
			AdjustEdgeInsets();
			ApplyStyle();

			TouchUpInside += (sender, args) => Selected = !Selected;
		}

		void AdjustEdgeInsets()
		{
			const float inset = 8f;

			HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			ImageEdgeInsets = new UIEdgeInsets(0f, inset, 0f, 0f);
			TitleEdgeInsets = new UIEdgeInsets(0f, inset * 2, 0f, 0f);
		}

		void ApplyStyle()
		{
			SetImage(UIImage.FromBundle("Images/CheckBox/checked_checkbox.png"), UIControlState.Selected);
			SetImage(UIImage.FromBundle("Images/CheckBox/unchecked_checkbox.png"), UIControlState.Normal);
		}
	}
}
