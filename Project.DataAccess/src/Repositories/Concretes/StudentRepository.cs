using Microsoft.EntityFrameworkCore;
using Project.DataAccess.Context;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.DataAccess.Repositories.Concretes
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(PostgresContext context)
            : base(context) { }

        public async Task<IList<Career>> GetCareers(Guid idStudent)
        {
            var student = await context
                .Set<Student>()
                .Include(st => st.StudentCareers)
                .ThenInclude(sc => sc.Career)
                .FirstAsync(st => st.Id.Equals(idStudent));

            return student.StudentCareers.Select(sc => sc.Career).ToList();
        }
    }
}
