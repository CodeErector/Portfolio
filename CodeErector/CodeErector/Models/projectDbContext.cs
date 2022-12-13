using Microsoft.EntityFrameworkCore;

namespace CodeErector.Models
{
    public class projectDbContext : DbContext
    {
        public projectDbContext(DbContextOptions<projectDbContext> options) : base(options)
        {

        }
        public DbSet<ContactDetails> ContactDetails { get; set; }
    }
}
