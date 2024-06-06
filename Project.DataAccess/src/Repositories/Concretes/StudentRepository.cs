using Project.DataAccess.Context;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.DataAccess.Repositories.Concretes
{
    public class StudentRepository
        : BaseEntityRelationRepository<Student, Career>,
            IStudentRepository
    {
        public StudentRepository(PostgresContext context)
            : base(context) { }
    }
}
