using Project.Business.Mediators.Interfaces;
using Project.DataAccess.Entities.Concretes;

namespace Project.Business.Mediators.Concretes.Students.Put
{
    public class PutStudent : IBaseEntityRequest<Student>
    {
        public Student Entity { get; set; } = new Student();
    }
}
