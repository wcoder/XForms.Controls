using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace XFormsControls.Controls
{
	public class CustomListView : StackLayout
	{
		private const string NamespaceForTemplates = "XFormsControls.Templates";

		public static BindableProperty ItemsSourceProperty =
			BindableProperty.Create<CustomListView, IEnumerable<object>>(o =>
				o.ItemsSource, default(IEnumerable<object>),
				propertyChanged: OnItemsSourceChanged);

		public static BindableProperty ItemTemplateProperty =
			BindableProperty.Create<CustomListView, string>(o =>
				o.ItemTemplate, default(string),
				propertyChanged: OnItemTemplateChanged);

		public event EventHandler ItemSelected;

		public IEnumerable<object> ItemsSource
		{
			get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
			set { SetValue(ItemsSourceProperty, value); }
		}

		public string ItemTemplate
		{
			get { return (string)GetValue(ItemTemplateProperty); }
			set { SetValue(ItemTemplateProperty, value); }
		}


		public void Refresh()
		{
			Children.Clear();
			if (ItemsSource != null)

				foreach (var value in ItemsSource)
				{
					var template = RenderTemplate();
					if (template != null)
					{
						template.BindingContext = value;
						var t = new TapGestureRecognizer();
						t.Tapped += OnItemSelected;
						template.GestureRecognizers.Add(t);
						Children.Add(template);
					}
				}
			if (ItemsSource == null || !Enumerable.Any(ItemsSource))
			{
				Children.Add(new ContentView { HeightRequest = 1 });
			}

		}


		private static void OnItemsSourceChanged(BindableObject bindable, IEnumerable oldvalue, IEnumerable newvalue)
		{
			var view = bindable as CustomListView;
			if (view != null)
			{
				view.Refresh();
			}
		}

		private static void OnItemTemplateChanged(BindableObject bindable, string oldvalue, string newvalue)
		{
		}

		private ContentView RenderTemplate()
		{
			var type = Type.GetType(string.Concat(NamespaceForTemplates, '.', ItemTemplate));
			if (type != null)
			{
				return (ContentView)Activator.CreateInstance(type);
			}
			return new ContentView
			{
				Content = new Label { Text = string.Format("Template '{0}' is not found", ItemTemplate) }
			};
		}

		private void OnItemSelected(object sender, EventArgs args)
		{
			if (ItemSelected != null)
			{
				ItemSelected(sender, args);
			}
		}
	}
}
