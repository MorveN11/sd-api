using Project.DataAccess.Entities.Interfaces;

namespace Project.DataAccess.Repositories.Interfaces
{
    public interface IBaseEntityRelationRepository<TEntity, TEntityRelation>
        : IBaseRepository<TEntity>
        where TEntityRelation : class, IBaseEntity, new()
        where TEntity : class, IBaseEntityRelation<TEntityRelation>, new()
    {
        Task<IList<TEntityRelation>?> GetRelations(Guid entityId);
    }
}
