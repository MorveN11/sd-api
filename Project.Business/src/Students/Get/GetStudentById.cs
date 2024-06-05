using MediatR;
using Project.DataAccess.Entities.Concretes;

namespace Project.Business.Students.Get
{
    public class GetStudentById : IRequest<Student>
    {
        public Guid StudentId { get; set; }

        public GetStudentById(Guid studentId)
        {
            StudentId = studentId;
        }
    }
}
