using BookerToDo.Services.Authorization;
using BookerToDo.Views;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookerToDo.ViewModels
{
    public class LoginPageViewModel : BaseViewModel
    {
        private readonly IAuthorizationService _authorizationService;

        public LoginPageViewModel()
        {
            _authorizationService = new AuthorizationService();
        }

        #region -- Public properties --

        public ICommand LogInTapCommand => new Command(OnLogInTapCommand);

        #endregion

        #region -- Private methods --

        private async void OnLogInTapCommand()
        {
            _authorizationService.LogIn(); ;
            await NavigationService.AbsoluteNavigateAsync(new MainListPage());
        }

        #endregion
    }
}
