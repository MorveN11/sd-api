using Project.Business.Mediators.Interfaces;
using Project.Core.Exceptions.Business;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Interfaces;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.Bases
{
    public abstract class BaseGetRelationsHandler<TEntity, TRelation, TRequest, TRepository>
        : BaseRequestHandler<TEntity, IList<TRelation>, TRequest, TRepository>
        where TRelation : class, IBaseEntity, new()
        where TEntity : class, IBaseEntityRelation<TRelation>, new()
        where TRequest : class, IBaseIdRelationRequest<TRelation>, new()
        where TRepository : IBaseEntityRelationRepository<TEntity, TRelation>
    {
        protected BaseGetRelationsHandler(TRepository repository, LogHandler logger)
            : base(repository, logger) { }

        public override async Task<IList<TRelation>> Handle(
            TRequest request,
            CancellationToken cancellationToken
        )
        {
            var response = await Repository.GetRelations(request.Id);

            if (response == null)
            {
                throw new NotFoundException<TEntity>(Logger);
            }

            return response;
        }
    }
}
