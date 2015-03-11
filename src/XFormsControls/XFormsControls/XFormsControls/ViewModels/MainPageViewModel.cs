using System.Collections.ObjectModel;
using Xamarin.Forms;
using XFormsControls.Models;

namespace XFormsControls.ViewModels
{
    class MainPageViewModel : BindableObject
    {
        private Member _member;

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
        }
    }
}
