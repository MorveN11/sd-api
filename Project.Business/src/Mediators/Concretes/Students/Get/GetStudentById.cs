using Project.Business.Mediators.Interfaces;
using Project.DataAccess.Entities.Concretes;

namespace Project.Business.Mediators.Concretes.Students.Get
{
    public class GetStudentById : IBaseIdRequest<Student>
    {
        public Guid Id { get; set; }
    }
}
