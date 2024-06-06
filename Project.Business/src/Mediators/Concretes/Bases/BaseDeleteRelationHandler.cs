using Project.Business.Mediators.Interfaces;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Interfaces;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.Bases
{
    public abstract class BaseDeleteRelationHandler<
        TFirstEntity,
        TSecondEntity,
        TRequest,
        TRepository
    > : BaseRelationHandler<TFirstEntity, TSecondEntity, TRequest, TRepository>
        where TFirstEntity : class, IBaseEntityRelation<TSecondEntity>, new()
        where TSecondEntity : class, IBaseEntityRelation<TFirstEntity>, new()
        where TRequest : class, IBaseRelationRequest, new()
        where TRepository : IBaseRelationRepository<TFirstEntity, TSecondEntity>
    {
        protected BaseDeleteRelationHandler(TRepository repository, LogHandler logger)
            : base(repository, logger) { }

        public override async Task<int> Operation(
            TRepository repository,
            Guid firstEntityId,
            Guid secondEntityId
        )
        {
            return await Repository.RemoveRelation(firstEntityId, secondEntityId);
        }
    }
}
