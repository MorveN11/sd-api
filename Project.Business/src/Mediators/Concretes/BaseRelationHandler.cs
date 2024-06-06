using MediatR;
using Project.Business.Mediators.Interfaces;
using Project.Core.Exceptions.Business;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Interfaces;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes
{
    public abstract class BaseRelationHandler<TFirstEntity, TSecondEntity, TRequest, TRepository>
        : IRequestHandler<TRequest, bool>
        where TFirstEntity : class, IBaseEntityRelation<TSecondEntity>, new()
        where TSecondEntity : class, IBaseEntityRelation<TFirstEntity>, new()
        where TRequest : class, IBaseRelationRequest, new()
        where TRepository : IBaseRelationRepository<TFirstEntity, TSecondEntity>
    {
        protected readonly TRepository Repository;
        protected readonly LogHandler Logger;

        protected BaseRelationHandler(TRepository repository, LogHandler logger)
        {
            Repository = repository;
            Logger = logger;
        }

        public abstract Task<int> Operation(
            TRepository repository,
            Guid firstEntityId,
            Guid secondEntityId
        );

        public async Task<bool> Handle(TRequest request, CancellationToken cancellationToken)
        {
            var response = await Operation(Repository, request.FirstId, request.SecondId);

            _ = response switch
            {
                404 => throw new NotFoundException(Logger),
                409 => throw new DuplicateIdException(Logger),
                _ => true
            };

            return true;
        }
    }
}
