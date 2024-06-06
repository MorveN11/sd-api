using MediatR;

namespace Project.Business.Mediators.Interfaces
{
    public interface IBaseIdBoolRequest : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
