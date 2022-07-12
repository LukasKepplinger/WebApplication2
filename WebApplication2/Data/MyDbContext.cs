using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
        {

        }
        public DbSet<Person> Persons { get; set; }
    }
}
