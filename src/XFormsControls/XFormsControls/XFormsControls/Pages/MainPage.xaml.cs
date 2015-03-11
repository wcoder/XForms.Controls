using Xamarin.Forms;

namespace XFormsControls.Pages
{
    public partial class MainPage : ContentPage
    {
        private string _mainText;

        public string MainText
        {
            get { return _mainText; }
            set
            {
                _mainText = value;
                OnPropertyChanged();
            }
        }


        public MainPage()
        {
            InitializeComponent();

            BindingContext = this;

            MainText = "Welcome to Xamarin Forms!";
        }
    }
}
