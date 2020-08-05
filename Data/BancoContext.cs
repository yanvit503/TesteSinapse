
using Microsoft.EntityFrameworkCore;
using TesteSinapse.Models;

namespace TesteSinapse.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options)
            : base(options)
        { }

        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Fatura> Faturas { get; set; }
    }
}