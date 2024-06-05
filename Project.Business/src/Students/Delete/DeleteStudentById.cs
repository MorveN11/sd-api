using MediatR;

namespace Project.Business.Students.Delete
{
    public class DeleteStudentById : IRequest<int>
    {
        public Guid StudentId { get; set; }

        public DeleteStudentById(Guid studentId)
        {
            StudentId = studentId;
        }
    }
}
