using Project.Business.Mediators.Concretes.Bases;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.Students.Delete
{
    public class DeleteStudentByIdHandler
        : BaseDeleteEntityByIdHandler<Student, DeleteStudentById, IStudentRepository>
    {
        public DeleteStudentByIdHandler(IStudentRepository repository, LogHandler logger)
            : base(repository, logger) { }
    }
}
