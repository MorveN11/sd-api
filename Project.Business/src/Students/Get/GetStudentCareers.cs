using MediatR;
using Project.DataAccess.Entities.Concretes;

namespace Project.Business.Students.Get
{
    public class GetStudentCareers : IRequest<IList<Career>>
    {
        public Guid StudentId { get; set; }

        public GetStudentCareers(Guid studentId)
        {
            StudentId = studentId;
        }
    }
}
