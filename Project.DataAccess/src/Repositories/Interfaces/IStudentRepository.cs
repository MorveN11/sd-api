using Project.DataAccess.Entities.Concretes;

namespace Project.DataAccess.Repositories.Interfaces
{
    public interface IStudentRepository : IBaseEntityRelationRepository<Student, Career> { }
}
