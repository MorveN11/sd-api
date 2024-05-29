using Project.DataAccess.Entities.Concretes;

namespace Project.DataAccess.Repositories.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<IList<Career>> GetCareers(Guid idStudent);
    }
}
