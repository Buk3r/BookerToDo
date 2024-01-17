using System.Windows.Input;
using Xamarin.Forms;

namespace BookerToDo.ViewModels
{
    public class AddEditTaskPageViewModel : BaseViewModel
    {
        #region -- Public properties --

        private string _taskName;
        public string TaskName
        {
            get { return _taskName; }
            set { SetProperty(ref _taskName, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public ICommand SaveTaskTapCommand => new Command(OnSaveTaskTapCommand);

        #endregion

        #region -- Private methods --

        private async void OnSaveTaskTapCommand()
        {
            if (App.Current.MainPage is NavigationPage navPage)
            {
                await navPage.CurrentPage.Navigation.PopAsync();
            }
        }

        #endregion
    }
}