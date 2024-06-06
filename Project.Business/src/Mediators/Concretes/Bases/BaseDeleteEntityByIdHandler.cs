using Project.Business.Mediators.Interfaces;
using Project.Core.Exceptions.Business;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Interfaces;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.Bases
{
    public abstract class BaseDeleteEntityByIdHandler<TEntity, TRequest, TRepository>
        : BaseRequestHandler<TEntity, bool, TRequest, TRepository>
        where TEntity : class, IBaseEntity, new()
        where TRequest : class, IBaseIdBoolRequest, new()
        where TRepository : IBaseRepository<TEntity>
    {
        protected BaseDeleteEntityByIdHandler(TRepository repository, LogHandler logger)
            : base(repository, logger) { }

        public override async Task<bool> Handle(
            TRequest request,
            CancellationToken cancellationToken
        )
        {
            var response = await Repository.Delete(new TEntity { Id = request.Id });

            if (!response)
            {
                throw new NotFoundException<TEntity>(Logger);
            }

            return response;
        }
    }
}
