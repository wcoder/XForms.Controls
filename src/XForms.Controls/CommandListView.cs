using System.Windows.Input;
using Xamarin.Forms;

namespace XForms.Controls
{
	public class CommandListView : ListView
	{
		public static BindableProperty SelectedItemCommandProperty =
				BindableProperty.Create<CommandListView, ICommand>(o => o.SelectItemCommand,
					default(ICommand), BindingMode.OneWay, null,
					null, null, null);

		public ICommand SelectItemCommand
		{
			get { return (ICommand)GetValue(SelectedItemCommandProperty); }
			set { SetValue(SelectedItemCommandProperty, value); }
		}

		public CommandListView()
		{
			ItemSelected += XListView_ItemSelected;
		}

		private void XListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var listView = sender as ListView;
			if (listView != null)
			{
				if (SelectItemCommand != null)
				{
					if (listView.SelectedItem != null)
					{
						SelectItemCommand.Execute(listView.SelectedItem);
						listView.SelectedItem = null;
					}
				}
			}
		}
	}
}
