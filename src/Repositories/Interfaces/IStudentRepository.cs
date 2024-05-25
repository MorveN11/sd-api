using Api.Entities;

namespace Api.Repositories.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<int> GetCareers(Guid isStudent);
    }
}
