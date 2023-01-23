using Intergado.Business.Model;
using Microsoft.EntityFrameworkCore;

namespace Intergado.Data.Context
{
    public class IntergadoContext : DbContext
    {
        public IntergadoContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<FazendaEntity> Fazendas { get; set; }

        public DbSet<AnimalEntity> Animais { get; set; }
    }
}