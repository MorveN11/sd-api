using Microsoft.EntityFrameworkCore;
using Project.DataAccess.Context;
using Project.DataAccess.Entities.Interfaces;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.DataAccess.Repositories.Concretes
{
    public abstract class BaseRepository<T> : IBaseRepository<T>
        where T : class, IBaseEntity, new()
    {
        protected readonly PostgresContext Context;

        protected BaseRepository(PostgresContext context)
        {
            Context = context;
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }

        public async Task<T?> Create(T entity)
        {
            var exists = await Exists(entity.Id);

            if (exists)
            {
                return null;
            }

            Context.Set<T>().Add(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<T?> GetById(Guid id)
        {
            return await Context.Set<T>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<T?> Update(T entity)
        {
            var exists = await Exists(entity.Id);

            if (!exists)
            {
                return null;
            }

            Context.Set<T>().Update(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(T entity)
        {
            var exists = await Exists(entity.Id);

            if (!exists)
            {
                return false;
            }

            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Exists(Guid id)
        {
            return await Context.Set<T>().AnyAsync(x => x.Id.Equals(id));
        }
    }
}
