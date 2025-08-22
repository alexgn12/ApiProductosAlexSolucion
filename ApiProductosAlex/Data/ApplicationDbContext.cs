using Microsoft.EntityFrameworkCore;
using ApiProductosAlex.Entities;

namespace ApiProductosAlex.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        // Puedes configurar m�s entidades o reglas aqu� si es necesario
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     base.OnModelCreating(modelBuilder);
        // }
    }
}
