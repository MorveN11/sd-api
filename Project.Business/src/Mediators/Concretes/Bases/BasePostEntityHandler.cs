using Project.Business.Mediators.Interfaces;
using Project.Core.Exceptions.Business;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Interfaces;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.Bases
{
    public abstract class BasePostEntityHandler<TResponse, TRequest, TRepository>
        : BaseEntityRequestHandler<TResponse, TRequest, TRepository>
        where TResponse : class, IBaseEntity, new()
        where TRequest : class, IBaseEntityRequest<TResponse>, new()
        where TRepository : IBaseRepository<TResponse>
    {
        protected BasePostEntityHandler(TRepository repository, LogHandler logger)
            : base(repository, logger) { }

        public override async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken
        )
        {
            var response = await Repository.Create(request.Entity);

            if (response == null)
            {
                throw new DuplicateIdException(Logger);
            }

            return response;
        }
    }
}
