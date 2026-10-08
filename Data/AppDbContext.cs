using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoMecanica.Models;

namespace ProjetoMecanica.Data
{
    public class AppDbContext : DbContext
    {
        internal Task<ActionResult<IEnumerable<Veiculo>>> vue;

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<Agendamento> Agendamentos { get; set; }
    }
}
