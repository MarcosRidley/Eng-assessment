using Microsoft.EntityFrameworkCore;
using Models.Entities.User;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Eng_assessment.Configuration
{
    public class MyDbContext(DbContextOptions<MyDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
