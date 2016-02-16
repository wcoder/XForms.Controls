using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using XForms.Controls.Samples.Models;

namespace XForms.Controls.Samples.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		public ObservableCollection<Book> Books { get; private set; }
		public ICommand SelectBookCommand { get; private set; }

		public MainViewModel()
		{
			Books = new ObservableCollection<Book>();
			SelectBookCommand = new Command<Book>(SelectBook);

			for (int i = 0; i < 20; i++)
			{
				Books.Add(new Book
				{
					Name = $"Book N.{i.ToString()}"
				});
			}
		}

		private void SelectBook(Book book)
		{
			Title = book.Name;
		}
	}
}
