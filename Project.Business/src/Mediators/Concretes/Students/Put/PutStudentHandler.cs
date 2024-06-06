using Project.Business.Mediators.Concretes.Bases;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.Students.Put
{
    public class PutStudentHandler : BasePutEntityHandler<Student, PutStudent, IStudentRepository>
    {
        public PutStudentHandler(IStudentRepository repository, LogHandler logger)
            : base(repository, logger) { }
    }
}
