using MediatR;
using Project.DataAccess.Entities.Interfaces;

namespace Project.Business.Mediators.Interfaces
{
    public interface IBaseEntityRequest<T> : IRequest<T>
        where T : class, IBaseEntity, new()
    {
        public T Entity { get; set; }
    }
}
