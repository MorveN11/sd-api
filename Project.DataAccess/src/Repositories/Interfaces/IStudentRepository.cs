using Project.DataAccess.Entities.Concretes;

namespace Project.DataAccess.Repositories.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<int> GetCareers(Guid isStudent);
    }
}
