using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using XFormsControls.Models;

namespace XFormsControls.ViewModels
{
	class MainPageViewModel : BindableObject
	{
		private Member _member;
		private ICommand _addCommand;

		public Member Member
		{
			get { return _member; }
			set
			{
				_member = value;
				OnPropertyChanged();
			}
		}

		public ObservableCollection<Member> Members { get; set; }
		public ObservableCollection<Book> Books { get; set; }

		public ICommand AddCommand
		{
			get
			{
				_addCommand = _addCommand ?? new Command(AddBook);
				return _addCommand;
			}
		}

		public MainPageViewModel()
		{
			Members = new ObservableCollection<Member>
			{
				new Member
				{
					FirstName = "Ivan",
					LastName = "Ivanov"
				}
			};

			Books = new ObservableCollection<Book>
			{
				new Book { Name = "Book 1" },
				new Book { Name = "Book 2" }
			};
		}

		private void AddBook()
		{
			Books.Add(new Book {Name = string.Format("New book #{0}", DateTime.Now.Ticks)});

			// TODO: add auto-update control items on UI
		}
	}
}
