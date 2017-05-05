using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace XamarinLocalDataAccessDemo.Models
{
    public class DishDbContext : DbContext
    {
        private readonly string _databasePath;

        public DishDbContext(string databasePath)
        {
            _databasePath = Path.Combine(databasePath, "dishes.db");
        }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
