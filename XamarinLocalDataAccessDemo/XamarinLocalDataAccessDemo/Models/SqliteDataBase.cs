using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using SQLite;

namespace XamarinLocalDataAccessDemo.Models
{
    public class SqliteDataBase
    {
        private SQLiteAsyncConnection _database;

        public SqliteDataBase(string path)
        {
            path = Path.Combine(path, "dishes.sqlite");
            _database = new SQLiteAsyncConnection(path);
            _database.CreateTableAsync<Dish>().Wait();
        }

        public Task<List<Dish>> GetDishesAsync()
        {
            return _database.Table<Dish>().ToListAsync();
        }


        public Task<Dish> GetDishAsync(int id)
        {
            return _database.Table<Dish>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveDishAsync(Dish item)
        {
            if (item.Id != 0)
            {
                return _database.UpdateAsync(item);
            }
            else
            {
                return _database.InsertAsync(item);
            }
        }

        public Task<int> DeleteDishAsync(Dish item)
        {
            return _database.DeleteAsync(item);
        }
    }
}