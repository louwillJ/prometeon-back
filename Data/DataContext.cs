using Microsoft.EntityFrameworkCore;
using prometeon_back.Models;

namespace prometeon_back.Data {
    public class DataContext : DbContext {
        public DataContext (DbContextOptions<DataContext> options) : base (options) {

        }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {
            // .UseSqlServer (connectionString, providerOptions => providerOptions.CommandTimeout (60))
            //     .UseQueryTrackingBehavior (QueryTrackingBehavior.NoTracking);
            // optionsBuilder.EnableSensitiveDataLogging ();
            // ...
        }

        public DbSet<Usuario> MD_USERS { get; set; }
        public DbSet<Turno> MD_TURNO { get; set; }
        public DbSet<TurnoException> MD_TURNO_EXCEPTION { get; set; }
        public DbSet<PlantModel> MD_ORGANIZATIONAL_ITEM { get; set; }
        public DbSet<OrdemProducao> MD_PRODUCTION_ORDER { get; set; }
        public DbSet<OrdemStatus> MD_PRODUCTION_ORDER_STATUS { get; set; }
    }
}