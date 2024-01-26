using BookerToDo.Models.Task;
using System.Windows.Input;

namespace BookerToDo.Extensions
{
    public static class TaskExtensions
    {
        public static TaskModel ToModel(this TaskViewModel viewModel)
        {
            return new TaskModel
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Description = viewModel.Description,
                IsDone = viewModel.IsDone,
            };
        }

        public static TaskViewModel ToViewModel(
            this TaskModel model,
            ICommand doneTapCommand = null,
            ICommand editTapCommand = null,
            ICommand deleteTapCommand = null)
        {
            return new TaskViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                IsDone = model.IsDone,
                DoneTapCommand = doneTapCommand,
                DeleteTapCommand = deleteTapCommand,
                EditTapCommand = editTapCommand,
            };
        }
    }
}
