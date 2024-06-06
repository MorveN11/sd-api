using Project.Business.Mediators.Interfaces;
using Project.DataAccess.Entities.Concretes;

namespace Project.Business.Mediators.Concretes.Students.Post
{
    public class PostStudent : IBaseEntityRequest<Student>
    {
        public Student Entity { get; set; } = new Student();
    }
}
