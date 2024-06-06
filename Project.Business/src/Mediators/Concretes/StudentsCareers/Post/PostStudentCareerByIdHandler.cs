using Project.Business.Mediators.Concretes.Bases;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.StudentsCareers.Post
{
    public class PostStudentCareerByIdHandler
        : BasePostRelationHandler<Student, Career, PostStudentCareerById, IStudentCareerRepository>
    {
        public PostStudentCareerByIdHandler(IStudentCareerRepository repository, LogHandler logger)
            : base(repository, logger) { }
    }
}
