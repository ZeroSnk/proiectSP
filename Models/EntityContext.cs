using Microsoft.EntityFrameworkCore;
namespace WebApplication2.Models
{
    public class EntityContext : DbContext
    {

        public EntityContext(DbContextOptions<EntityContext> options)
            : base(options)
        {
            Database.EnsureCreated(); 
        }
        public DbSet<Entity> Entities { get; set; }
    }
}
