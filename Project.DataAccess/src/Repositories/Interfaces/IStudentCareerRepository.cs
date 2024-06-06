using Project.DataAccess.Entities.Concretes;

namespace Project.DataAccess.Repositories.Interfaces
{
    public interface IStudentCareerRepository : IBaseRelationRepository<Student, Career> { }
}
