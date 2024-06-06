using Project.DataAccess.Entities.Interfaces;

namespace Project.DataAccess.Repositories.Interfaces
{
    public interface IBaseRelationRepository<TFirstEntity, TSecondEntity>
        where TFirstEntity : class, IBaseEntityRelation<TSecondEntity>, new()
        where TSecondEntity : class, IBaseEntityRelation<TFirstEntity>, new()
    {
        Task<(TFirstEntity? FirstEntity, TSecondEntity? SecondEntity, int Status)?> CheckExists(
            Guid firstEntityId,
            Guid secondEntityId
        );

        Task<(TFirstEntity? FirstEntity, TSecondEntity? SecondEntity, int Status)?> CheckRelation(
            Guid firstEntityId,
            Guid secondEntityId
        );
        Task<int> AddRelation(Guid firstEntityId, Guid secondEntityId);
        Task<int> RemoveRelation(Guid firstEntityId, Guid secondEntityId);
    }
}
