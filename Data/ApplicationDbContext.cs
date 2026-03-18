using Microsoft.EntityFrameworkCore;
using full_structure_db.Entities;

namespace full_structure_db.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}