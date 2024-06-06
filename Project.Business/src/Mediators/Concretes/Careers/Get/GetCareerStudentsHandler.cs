using Project.Business.Mediators.Concretes.Bases;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.Careers.Get
{
    public class GetCareerStudentsHandler
        : BaseGetRelationsHandler<Career, Student, GetCareerStudents, ICareerRepository>
    {
        public GetCareerStudentsHandler(ICareerRepository repository, LogHandler logger)
            : base(repository, logger) { }
    }
}
