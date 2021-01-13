using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.Order.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Entities.Order> Order { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
