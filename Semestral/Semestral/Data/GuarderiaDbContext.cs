using Microsoft.EntityFrameworkCore;
using Guarderia.api.Models;

namespace Guarderia.api.Data
{
    public class GuarderiaDbContext : DbContext
    {
        public GuarderiaDbContext(DbContextOptions<GuarderiaDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Padre>().ToTable("Padres");
            modelBuilder.Entity<Padre>().HasKey(p => p.ParentID);
            modelBuilder.Entity<Nino>().ToTable("Ninos");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Factura>().ToTable("Facturas");
            modelBuilder.Entity<Pago>().ToTable("Pagos");
        }

        public DbSet<Padre> Padres { get; set; }
        public DbSet<Nino> Ninos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<Factura> Facturas { get; set; }
    }
}
