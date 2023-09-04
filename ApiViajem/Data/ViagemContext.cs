using ApiViajem.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiViajem.Data
{
    public class ViagemContext : DbContext
    {
       
            public ViagemContext(DbContextOptions<ViagemContext> opts) : base(opts)
            {

            }

            public DbSet<Depoimento> Depoimentos { get; set; }
            public DbSet<Destino> Destinos { get; set; }
        }
    }


