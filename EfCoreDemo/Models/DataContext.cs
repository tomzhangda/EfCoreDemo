using Microsoft.EntityFrameworkCore;

namespace EfCoreDemo.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Class> Classes { get; set; }
    }
}
