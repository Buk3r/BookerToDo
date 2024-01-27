using BookerToDo.ViewModels;

namespace BookerToDo.Views
{
    public partial class LoginPage : BaseContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = new LoginPageViewModel();
        }
    }
}