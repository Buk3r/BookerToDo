using BookerToDo.Extensions;
using BookerToDo.Models.Task;
using BookerToDo.Services.ToDoTask;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookerToDo.ViewModels
{
    public class AddEditTaskPageViewModel : BaseViewModel
    {
        private readonly IToDoTaskService _toDoTaskService;

        private TaskViewModel _toDoTask;

        public AddEditTaskPageViewModel()
        {
            _toDoTaskService = new ToDoTaskService();
            BackButtonPressedAction = OnBackButtonPressed;
        }

        #region -- Public properties --

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private TaskViewModel _currentTask;
        public TaskViewModel CurrentTask
        {
            get { return _currentTask; }
            set { SetProperty(ref _currentTask, value); }
        }

        public ICommand SaveTaskTapCommand => new Command(OnSaveTaskTapCommand);

        #endregion

        #region -- Overrides --

        public override void Initialize(IDictionary<string, object> parameters)
        {
            base.Initialize(parameters);

            if (parameters.TryGetValue(Constants.Navigation.EDIT_TASK, out object parameter)
                && parameter is TaskModel task)
            {
                _toDoTask = task.ToViewModel();
                CurrentTask = task.ToViewModel();
                Title = "Edit task";
            }
            else
            {
                _toDoTask = new TaskViewModel();
                CurrentTask = new TaskViewModel();
                Title = "Add task";
            }
        }

        #endregion

        #region -- Public methods --

        private async void OnBackButtonPressed()
        {
            if (CurrentTask.Title != _toDoTask.Title
                || CurrentTask.Description != _toDoTask.Description)
            {
                var isDiscardConfirmed = await DialogService.DisplayAlert(
                    "Confirm",
                    "Do you want to discard changes?",
                    "Yes",
                    "No");

                if (isDiscardConfirmed)
                {
                    await NavigationService.GoBackAsync();
                }
            }
            else
            {
                await NavigationService.GoBackAsync();
            }
        }

        #endregion

        #region -- Private methods --

        private async void OnSaveTaskTapCommand()
        {
            if (!string.IsNullOrWhiteSpace(CurrentTask.Title))
            {
                await _toDoTaskService.SaveTaskAsync(CurrentTask.ToModel());

                await NavigationService.GoBackAsync();
            }
            else
            {
                await DialogService.DisplayAlert("Ooops", "Title must be not empty", "Ok");
            }
        }

        #endregion
    }
}