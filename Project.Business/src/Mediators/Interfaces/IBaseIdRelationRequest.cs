using MediatR;
using Project.DataAccess.Entities.Interfaces;

namespace Project.Business.Mediators.Interfaces
{
    public interface IBaseIdRelationRequest<T> : IRequest<IList<T>>
        where T : class, IBaseEntity, new()
    {
        public Guid Id { get; set; }
    }
}
