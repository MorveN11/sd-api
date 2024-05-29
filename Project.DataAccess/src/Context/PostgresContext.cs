using Microsoft.EntityFrameworkCore;
using Project.DataAccess.Entities.Concretes;

namespace Project.DataAccess.Context
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options)
            : base(options) { }

        public DbSet<Student>? Students { get; set; }
        public DbSet<Career>? Careers { get; set; }
        public DbSet<StudentCareer>? StudentCareers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
