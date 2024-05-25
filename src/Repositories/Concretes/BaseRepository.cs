using System.Linq.Expressions;
using Api.Context;
using Api.Entities;
using Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.Concretes
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class, IBaseEntity, new()
    {
        protected readonly PostgresContext context;

        protected BaseRepository(PostgresContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        public async Task<int> Create(T entity)
        {
            context.Set<T>().Add(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Update(T entity)
        {
            context.Set<T>().Update(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<int> Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            return await context.SaveChangesAsync();
        }

        public async Task<IList<T>> Read(Expression<Func<T, bool>> lambda)
        {
            lambda.Compile();
            return await context.Set<T>().Where(lambda).ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await context.Set<T>().FirstAsync(x => x.Id.Equals(id));
        }
    }
}
