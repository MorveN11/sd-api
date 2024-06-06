using Project.Business.Mediators.Concretes.Bases;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.Students.Get
{
    public class GetStudentCareersHandler
        : BaseGetRelationsHandler<Student, Career, GetStudentCareers, IStudentRepository>
    {
        public GetStudentCareersHandler(IStudentRepository repository, LogHandler logger)
            : base(repository, logger) { }
    }
}
