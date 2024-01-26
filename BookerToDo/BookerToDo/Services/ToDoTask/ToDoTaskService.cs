using BookerToDo.Models.Task;
using BookerToDo.Services.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookerToDo.Services.ToDoTask
{
    public class ToDoTaskService : IToDoTaskService
    {
        private readonly IRepository _repository;

        public ToDoTaskService()
        {
            _repository = Repository.Repository.GetInstance();
        }

        public Task SaveTaskAsync(TaskModel task)
        {
            return task.Id == default
                ? _repository.InsertAsync(task)
                : _repository.UpdateAsync(task);
        }

        public Task<List<TaskModel>> GetTasksAsync()
        {
            return _repository.GetAllAsync<TaskModel>();
        }

        public Task DeleteTaskAsync(TaskModel task)
        {
            return _repository.DeleteAsync(task);
        }
    }
}
