using Academy_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy_2024.Data
{
    public class Applicationdbcontent : DbContext
    {
        private readonly string _dbPath;

        public Applicationdbcontent() {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            _dbPath = Path.Combine(path, "academy.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
