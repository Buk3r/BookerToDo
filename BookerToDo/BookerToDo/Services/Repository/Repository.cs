using BookerToDo.Models;
using BookerToDo.Models.Task;
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
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Constants.DB_NAME);
            _connection = new SQLiteAsyncConnection(path);
        }

        public static Repository GetInstance()
        {
            if (_instance is null)
            {
                _instance = new Repository();
            }

            return _instance;
        }

        public async Task<int> InsertAsync<T>(T entity) where T : IEntityBase, new()
        {
            await CreateTablesAsync();
            return await _connection.InsertAsync(entity);
        }

        public async Task<List<T>> GetAllAsync<T>() where T : IEntityBase, new()
        {
            await CreateTablesAsync();
            return await _connection.Table<T>().ToListAsync();
        }

        public async Task<int> UpdateAsync<T>(T entity) where T : IEntityBase, new()
        {
            await CreateTablesAsync();
            return await _connection.UpdateAsync(entity);
        }

        public async Task<int> DeleteAsync<T>(T entity) where T : IEntityBase, new()
        {
            await CreateTablesAsync();
            return await _connection.DeleteAsync(entity);
        }

        private async Task CreateTablesAsync()
        {
            await _connection.CreateTableAsync<TaskModel>();
        }
    }
}
