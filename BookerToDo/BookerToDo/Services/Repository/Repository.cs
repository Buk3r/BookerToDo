using BookerToDo.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BookerToDo.Services.Repository
{
    public class Repository : IRepository
    {
        private readonly SQLiteAsyncConnection _connection;

        private static Repository _instance;

        private Repository()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bookertodo.db3");
            _connection = new SQLiteAsyncConnection(path);
            CreateTablesAsync();
        }

        public static Repository GetInstance()
        {
            if (_instance is null)
            {
                _instance = new Repository();
            }

            return _instance;
        }

        public Task<int> InsertAsync<T>(T entity) where T : IEntityBase, new()
        {
            return _connection.InsertAsync(entity);
        }

        public Task<List<T>> GetAllAsync<T>() where T : IEntityBase, new()
        {
            return _connection.Table<T>().ToListAsync();
        }

        public Task<int> UpdateAsync<T>(T entity) where T : IEntityBase, new()
        {
            return _connection.UpdateAsync(entity);
        }

        public Task<int> DeleteAsync<T>(T entity) where T : IEntityBase, new()
        {
            return _connection.DeleteAsync(entity);
        }

        private async Task CreateTablesAsync()
        {
            await _connection.CreateTableAsync<TaskModel>();
        }
    }
}
