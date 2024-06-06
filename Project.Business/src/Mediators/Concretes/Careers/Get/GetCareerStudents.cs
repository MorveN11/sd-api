using Project.Business.Mediators.Interfaces;
using Project.DataAccess.Entities.Concretes;

namespace Project.Business.Mediators.Concretes.Careers.Get
{
    public class GetCareerStudents : IBaseIdRelationRequest<Student>
    {
        public Guid Id { get; set; }
    }
}
