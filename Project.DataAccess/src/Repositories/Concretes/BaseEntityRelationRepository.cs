using Microsoft.EntityFrameworkCore;
using Project.DataAccess.Context;
using Project.DataAccess.Entities.Interfaces;
using Project.DataAccess.Repositories.Interfaces;
using Project.DataAccess.Services;

namespace Project.DataAccess.Repositories.Concretes
{
    public abstract class BaseEntityRelationRepository<TEntity, TEntityRelation>
        : BaseRepository<TEntity>,
            IBaseEntityRelationRepository<TEntity, TEntityRelation>
        where TEntityRelation : class, IBaseEntity, new()
        where TEntity : class, IBaseEntityRelation<TEntityRelation>, new()
    {
        protected BaseEntityRelationRepository(
            ICachingService cachingService,
            PostgresContext context
        )
            : base(cachingService, context) { }

        public async Task<IList<TEntityRelation>?> GetRelations(Guid entityId)
        {
            return await CachingService.GetOrCreateAsync(
                $"{typeof(TEntity).Name}_{entityId}",
                async token =>
                {
                    var entity = await Context
                        .Set<TEntity>()
                        .Include(s => s.Relations)
                        .FirstOrDefaultAsync(s => s.Id.Equals(entityId), token);

                    return entity?.Relations;
                },
                [typeof(TEntity).Name]
            );
        }
    }
}
