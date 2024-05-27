using Project.DataAccess.Context;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.DataAccess.Repositories.Concretes
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(PostgresContext context)
            : base(context) { }

        public Task<int> GetCareers(Guid isStudent)
        {
            throw new NotImplementedException();
        }
    }
}
