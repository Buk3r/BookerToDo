using BookerToDo.Models.Task;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookerToDo.Services.ToDoTask
{
    public interface IToDoTaskService
    {
        Task SaveTaskAsync(TaskModel task);
        Task<List<TaskModel>> GetTasksAsync();

        Task DeleteTaskAsync(TaskModel task);
    }
}
