using Project.Core.Handlers;
using Project.DataAccess.Entities.Interfaces;

namespace Project.Core.Exceptions.Business
{
    public class NotFoundException<T> : BusinessException
        where T : class, IBaseEntity, new()
    {
        public NotFoundException(LogHandler logger)
            : base($"{typeof(T).Name} not found.", logger) { }
    }

    public class NotFoundException : BusinessException
    {
        public NotFoundException(LogHandler logger)
            : base("Resource not found.", logger) { }
    }
}
