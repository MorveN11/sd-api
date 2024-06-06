using MediatR;

namespace Project.Business.Mediators.Interfaces
{
    public interface IBaseRelationRequest : IRequest<bool>
    {
        public Guid FirstId { get; set; }
        public Guid SecondId { get; set; }
    }
}
