using Microsoft.EntityFrameworkCore;

namespace Project.DataAccess.Context
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
