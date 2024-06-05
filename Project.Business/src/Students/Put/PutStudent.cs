using MediatR;
using Project.DataAccess.Entities.Concretes;

namespace Project.Business.Students.Put
{
    public class PutStudent : IRequest<int>
    {
        public Student Student { get; set; }

        public PutStudent(Student student)
        {
            Student = student;
        }
    }
}
