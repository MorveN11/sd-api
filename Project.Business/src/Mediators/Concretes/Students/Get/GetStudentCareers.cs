using Project.Business.Mediators.Interfaces;
using Project.DataAccess.Entities.Concretes;

namespace Project.Business.Mediators.Concretes.Students.Get
{
    public class GetStudentCareers : IBaseIdRelationRequest<Career>
    {
        public Guid Id { get; set; }
    }
}
