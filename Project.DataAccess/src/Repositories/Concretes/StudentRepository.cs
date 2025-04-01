using Project.DataAccess.Context;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;
using Project.DataAccess.Services;

namespace Project.DataAccess.Repositories.Concretes
{
    public class StudentRepository
        : BaseEntityRelationRepository<Student, Career>,
            IStudentRepository
    {
        public StudentRepository(ICachingService cachingService, PostgresContext context)
            : base(cachingService, context) { }
    }
}
