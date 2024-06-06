using Project.Business.Mediators.Concretes.Bases;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.Students.Post
{
    public class PostStudentHandler
        : BasePostEntityHandler<Student, PostStudent, IStudentRepository>
    {
        public PostStudentHandler(IStudentRepository repository, LogHandler logger)
            : base(repository, logger) { }
    }
}
