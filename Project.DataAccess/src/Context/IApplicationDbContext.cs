using Microsoft.EntityFrameworkCore;
using Project.DataAccess.Entities.Concretes;

namespace Project.DataAccess.Context;

public interface IApplicationDbContext : IDisposable
{
    DbSet<Career> Careers { get; }
    DbSet<Student> Students { get; }

    DbSet<TEntity> Set<TEntity>()
        where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    int SaveChanges();
}
