using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XForms.Controls.Samples.Models;

namespace XForms.Controls.Samples.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private Book _pickerSelectedBook;
		private bool _isTouched;


		public ObservableCollection<Book> Books { get; private set; }
		public ICommand SelectBookCommand { get; private set; }
		public ICommand TapCommand { get; private set; }

		public Book PickerSelectedBook
		{
			get { return _pickerSelectedBook; }
			set { SetProperty(ref _pickerSelectedBook, value); }
		}

		public bool IsTouched
		{
			get { return _isTouched; }
			set { SetProperty(ref _isTouched, value); }
		}


		public MainViewModel()
		{
			Books = new ObservableCollection<Book>();
			SelectBookCommand = new Command<Book>(SelectBook);
			TapCommand = new Command(() => { IsTouched = true; });

			for (int i = 0; i < 20; i++)
			{
				Books.Add(new Book
				{
					Name = $"Book N.{i.ToString()}"
				});
			}

			PickerSelectedBook = Books.First();
		}

		private void SelectBook(Book book)
		{
			Title = book.Name;
		}
	}
}
