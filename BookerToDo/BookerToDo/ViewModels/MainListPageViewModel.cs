﻿using BookerToDo.Extensions;
using BookerToDo.Models.Task;
using BookerToDo.Services.Authorization;
using BookerToDo.Services.ToDoTask;
using BookerToDo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BookerToDo.ViewModels
{
    public class MainListPageViewModel : BaseViewModel
    {
        private readonly IToDoTaskService _toDoTaskService;
        private readonly IAuthorizationService _authorizationService;

        public MainListPageViewModel()
        {
            _toDoTaskService = new ToDoTaskService();
            _authorizationService = new AuthorizationService();
        }

        #region -- Public properties --

        private List<TaskViewModel> _tasks;
        public List<TaskViewModel> Tasks
        {
            get { return _tasks; }
            set { SetProperty(ref _tasks, value); }
        }

        public ICommand AddTaskTapCommand => new Command(OnAddTaskTapCommand);
        public ICommand LogOutTapCommand => new Command(OnLogOutTapCommand);

        #endregion

        #region -- Overrides --

        public override async void OnNavigatedTo(IDictionary<string, object> parameters)
        {
            base.OnNavigatedTo(parameters);

            await InitializeTasksAsync();
        }

        #endregion

        #region -- Private methods --

        private async Task InitializeTasksAsync()
        {
            var taskModels = await _toDoTaskService.GetTasksAsync();

            Tasks = taskModels.Select(t => t.ToViewModel(
                new Command<TaskViewModel>(OnDoneTapCommand),
                new Command<TaskViewModel>(OnEditTaskTapCommand),
                new Command<TaskViewModel>(OnDeleteTaskTapCommand))).ToList();
        }

        private async void OnAddTaskTapCommand()
        {
            await NavigationService.NavigateAsync(new AddEditTaskPage());
        }

        private async void OnDoneTapCommand(TaskViewModel task)
        {
            await _toDoTaskService.SaveTaskAsync(task.ToModel());
        }

        private async void OnEditTaskTapCommand(TaskViewModel task)
        {
            var parameters = new Dictionary<string, object>
            {
                { Constants.Navigation.EDIT_TASK, task.ToModel() }
            };

            await NavigationService.NavigateAsync(new AddEditTaskPage(), parameters);
        }

        private async void OnDeleteTaskTapCommand(TaskViewModel task)
        {
            var isDeleteConfirmed = await DialogService.DisplayAlert(
                Translate["Confirm"],
                Translate["ConfirmDeleteTaskMessage"],
                Translate["Yes"],
                Translate["No"]);

            if (isDeleteConfirmed)
            {
                await _toDoTaskService.DeleteTaskAsync(task.ToModel());
                await InitializeTasksAsync();
            }
        }

        private async void OnLogOutTapCommand()
        {
            _authorizationService.LogOut();
            await NavigationService.AbsoluteNavigateAsync(new LoginPage());
        }

        #endregion
    }
}
