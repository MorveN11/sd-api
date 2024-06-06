using Microsoft.EntityFrameworkCore;
using Project.DataAccess.Context;
using Project.DataAccess.Entities.Interfaces;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.DataAccess.Repositories.Concretes
{
    public abstract class BaseEntityRelationRepository<TEntity, TEntityRelation>
        : BaseRepository<TEntity>,
            IBaseEntityRelationRepository<TEntity, TEntityRelation>
        where TEntityRelation : class, IBaseEntity, new()
        where TEntity : class, IBaseEntityRelation<TEntityRelation>, new()
    {
        protected BaseEntityRelationRepository(PostgresContext context)
            : base(context) { }

        public async Task<IList<TEntityRelation>?> GetRelations(Guid entityId)
        {
            var entity = await Context
                .Set<TEntity>()
                .Include(s => s.Relations)
                .FirstOrDefaultAsync(s => s.Id.Equals(entityId));

            return entity?.Relations ?? null;
        }
    }
}
