using Academy_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy_2024.Data
{
    public class Applicationdbcontent : DbContext
    {

        public Applicationdbcontent(DbContextOptions options) : base(options) {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
