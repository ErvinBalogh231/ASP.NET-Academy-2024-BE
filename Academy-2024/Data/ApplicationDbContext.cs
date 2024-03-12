using Academy_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace Academy_2024.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options) {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}
