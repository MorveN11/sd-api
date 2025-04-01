using Microsoft.EntityFrameworkCore;
using Project.DataAccess.Entities.Concretes;

namespace Project.DataAccess.Context;

public class PostgresContext : DbContext, IApplicationDbContext
{
    public DbSet<Career> Careers { get; init; }
    public DbSet<Student> Students { get; init; }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostgresContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
