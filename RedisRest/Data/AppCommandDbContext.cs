using RedisRest.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.AppCommandDbContext
{
    public class AppCommandDbContext : DbContext
    {
        public AppCommandDbContext(DbContextOptions<AppCommandDbContext> options):base(options){
           
        }

        public DbSet<Macmiilka> Macmiilkas { get; set; }

    }
}