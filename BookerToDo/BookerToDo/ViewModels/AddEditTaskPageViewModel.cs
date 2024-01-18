using BookerToDo.Models;
using BookerToDo.Services.ToDoTask;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookerToDo.ViewModels
{
    public class AddEditTaskPageViewModel : BaseViewModel
    {
        private readonly IToDoTaskService _toDoTaskService;

        public AddEditTaskPageViewModel()
        {
            _toDoTaskService = new ToDoTaskService();
        }

        #region -- Public properties --

        private string _taskTitle;
        public string TaskTitle
        {
            get { return _taskTitle; }
            set { SetProperty(ref _taskTitle, value); }
        }

        private string _description;
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public ICommand SaveTaskTapCommand => new Command(OnSaveTaskTapCommand);

        #endregion

        #region -- Public methods --

        public bool OnBackButtonPressed()
        {
            if (!string.IsNullOrWhiteSpace(TaskTitle) 
                || !string.IsNullOrWhiteSpace(Description))
            {
                if (App.Current.MainPage is NavigationPage navPage)
                {
                    navPage.CurrentPage.DisplayAlert("Ooops", "Task is not saved", "Ok");
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region -- Private methods --

        private async void OnSaveTaskTapCommand()
        {
            if (!string.IsNullOrWhiteSpace(TaskTitle))
            {
                var task = new TaskModel
                {
                    Title = TaskTitle,
                    Description = Description,
                };

                await _toDoTaskService.SaveTaskAsync(task);

                if (App.Current.MainPage is NavigationPage navPage)
                {
                    await navPage.CurrentPage.Navigation.PopAsync();
                }
            }
            else
            {
                if (App.Current.MainPage is NavigationPage navPage)
                {
                    await navPage.CurrentPage.DisplayAlert("Ooops", "Title must be not empty", "Ok");
                }
            }
        }

        #endregion
    }
}