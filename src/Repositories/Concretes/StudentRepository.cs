using Api.Context;
using Api.Entities;
using Api.Repositories.Interfaces;

namespace Api.Repositories.Concretes
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
