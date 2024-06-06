using Project.Business.Mediators.Interfaces;
using Project.Core.Exceptions.Business;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Interfaces;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.Bases
{
    public abstract class BaseGetEntityByIdHandler<TResponse, TRequest, TRepository>
        : BaseEntityRequestHandler<TResponse, TRequest, TRepository>
        where TResponse : class, IBaseEntity, new()
        where TRequest : class, IBaseIdRequest<TResponse>, new()
        where TRepository : IBaseRepository<TResponse>
    {
        protected BaseGetEntityByIdHandler(TRepository repository, LogHandler logger)
            : base(repository, logger) { }

        public override async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken
        )
        {
            var response = await Repository.GetById(request.Id);

            if (response == null)
            {
                throw new NotFoundException<TResponse>(Logger);
            }

            return response;
        }
    }
}
