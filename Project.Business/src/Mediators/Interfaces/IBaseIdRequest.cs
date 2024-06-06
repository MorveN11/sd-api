using MediatR;
using Project.DataAccess.Entities.Interfaces;

namespace Project.Business.Mediators.Interfaces
{
    public interface IBaseIdRequest<T> : IRequest<T>
        where T : class, IBaseEntity, new()
    {
        public Guid Id { get; set; }
    }
}
