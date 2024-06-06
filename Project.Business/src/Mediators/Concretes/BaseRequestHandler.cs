using MediatR;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Interfaces;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes
{
    public abstract class BaseRequestHandler<TRepositoryType, TResponse, TRequest, TRepository>
        : IRequestHandler<TRequest, TResponse>
        where TRepositoryType : class, IBaseEntity, new()
        where TRequest : class, IRequest<TResponse>, new()
        where TRepository : IBaseRepository<TRepositoryType>
    {
        protected readonly TRepository Repository;
        protected readonly LogHandler Logger;

        protected BaseRequestHandler(TRepository repository, LogHandler logger)
        {
            Repository = repository;
            Logger = logger;
        }

        public abstract Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken
        );
    }
}
