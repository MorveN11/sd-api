using Project.Business.Mediators.Interfaces;
using Project.DataAccess.Entities.Concretes;

namespace Project.Business.Mediators.Concretes.Careers.Get
{
    public class GetCareerById : IBaseIdRequest<Career>
    {
        public Guid Id { get; set; }
    }
}
