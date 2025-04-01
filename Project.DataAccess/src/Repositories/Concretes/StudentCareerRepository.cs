using Project.DataAccess.Context;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.DataAccess.Repositories.Concretes
{
    public class StudentCareerRepository
        : BaseRelationRepository<Student, Career>,
            IStudentCareerRepository
    {
        public StudentCareerRepository(IApplicationDbContext context)
            : base(context) { }
    }
}
