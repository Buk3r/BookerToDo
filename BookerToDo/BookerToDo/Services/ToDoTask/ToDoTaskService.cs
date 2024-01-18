using BookerToDo.Models;
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
            return _repository.InsertAsync(task);
        }

        public Task<List<TaskModel>> GetTasksAsync()
        {
            return _repository.GetAllAsync<TaskModel>();
        }
    }
}
