using Microsoft.EntityFrameworkCore;
using ClientesApi.Models;

namespace ClientesApi.Data
{
    public class ClientesDbContext : DbContext
    {
        public ClientesDbContext(DbContextOptions<ClientesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
