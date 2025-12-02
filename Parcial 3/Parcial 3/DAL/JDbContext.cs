using System.Data.Entity;
using System.Diagnostics;
using System.Xml.Linq;
using Parcial_3.Models;

namespace Parcial_3.DAL
{
    public class JDbContext : DbContext
    {
        public JDbContext() : base("name=DefaultConnection")
        {
        }

        public DbSet<Abogado> Abogados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Caso> Casos { get; set; }
        public DbSet<CasoCliente> CasoClientes { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Documento> Documentos { get; set; }
    }
}
