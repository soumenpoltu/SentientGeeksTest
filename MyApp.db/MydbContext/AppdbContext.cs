using Microsoft.EntityFrameworkCore;
using MyApp.Entity;
using MyApp.Entity.models;

namespace MyApp.db.MydbContext
{
    public class AppdbContext : DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> options)
          : base(options)
        {

        }
        public DbSet<EntityEmployee> Employees { get; set; }
        public DbSet<EntityLogin> AuthorizeUsers { get; set; }

    }
}
