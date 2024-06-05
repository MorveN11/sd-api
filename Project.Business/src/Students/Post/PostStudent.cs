using MediatR;
using Project.DataAccess.Entities.Concretes;

namespace Project.Business.Students.Post
{
    public class PostStudent : IRequest<int>
    {
        public Student Student { get; set; }

        public PostStudent(Student student)
        {
            Student = student;
        }
    }
}
