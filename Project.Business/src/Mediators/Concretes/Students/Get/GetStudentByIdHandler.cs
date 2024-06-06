using Project.Business.Mediators.Concretes.Bases;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.Students.Get
{
    public class GetStudentByIdHandler
        : BaseGetEntityByIdHandler<Student, GetStudentById, IStudentRepository>
    {
        public GetStudentByIdHandler(IStudentRepository repository, LogHandler logger)
            : base(repository, logger) { }
    }
}
