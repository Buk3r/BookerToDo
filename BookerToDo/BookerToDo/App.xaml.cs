using BookerToDo.Services.Authorization;
using BookerToDo.Services.Navigation;
using BookerToDo.Views;
using Xamarin.Forms;

namespace BookerToDo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var navigationService = new NavigationService();
            var authorizationService = new AuthorizationService();

            _ = !authorizationService.IsAuthorized
                ? navigationService.AbsoluteNavigateAsync(new LoginPage())
                : navigationService.AbsoluteNavigateAsync(new MainListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
