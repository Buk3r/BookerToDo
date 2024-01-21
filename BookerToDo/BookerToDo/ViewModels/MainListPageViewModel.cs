using BookerToDo.Extensions;
using BookerToDo.Models.Task;
using BookerToDo.Services.ToDoTask;
using BookerToDo.Views;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookerToDo.ViewModels
{
    public class MainListPageViewModel : BaseViewModel
    {
        private readonly IToDoTaskService _toDoTaskService;

        public MainListPageViewModel()
        {
            _toDoTaskService = new ToDoTaskService();
            InitializeTasks();
        }

        private List<TaskViewModel> _tasks;
        public List<TaskViewModel> Tasks
        {
            get { return _tasks; }
            set { SetProperty(ref _tasks, value); }
        }

        public ICommand AddTaskTapCommand => new Command(OnAddTaskTapCommand);

        public async void InitializeTasks()
        {
            var taskModels = await _toDoTaskService.GetTasksAsync();

            Tasks = taskModels.Select(t => t.ToViewModel(
                new Command<TaskViewModel>(OnDeleteTaskTapCommand),
                new Command<TaskViewModel>(OnEditTaskTapCommand))).ToList();
        }

        private async void OnAddTaskTapCommand()
        {
            if (App.Current.MainPage is NavigationPage navPage)
            {
                await navPage.CurrentPage.Navigation.PushAsync(new AddEditTaskPage());
            }
        }

        private async void OnDeleteTaskTapCommand(TaskViewModel task)
        {
            if (App.Current.MainPage is NavigationPage navPage)
            {
                var isDeleteConfirmed = await navPage.CurrentPage.DisplayAlert(
                        "Confirm",
                        "Do you want to delete task?",
                        "Yes",
                        "No");

                if (isDeleteConfirmed)
                {
                    await _toDoTaskService.DeleteTaskAsync(task.ToModel());
                    InitializeTasks();
                }
            }  
        }

        private async void OnEditTaskTapCommand(TaskViewModel model)
        {
            if (App.Current.MainPage is NavigationPage navPage)
            {
                await navPage.CurrentPage.Navigation.PushAsync(new AddEditTaskPage());
            }
        }
    }
}
