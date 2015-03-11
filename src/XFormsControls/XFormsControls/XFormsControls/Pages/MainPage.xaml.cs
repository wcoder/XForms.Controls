using Xamarin.Forms;
using XFormsControls.ViewModels;

namespace XFormsControls.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new MainPageViewModel();
        }
    }
}
