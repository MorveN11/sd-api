using Project.Business.Mediators.Concretes.Bases;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.StudentsCareers.Delete
{
    public class DeleteStudentCareerByIdHandler
        : BaseDeleteRelationHandler<
            Student,
            Career,
            DeleteStudentCareerById,
            IStudentCareerRepository
        >
    {
        public DeleteStudentCareerByIdHandler(
            IStudentCareerRepository repository,
            LogHandler logger
        )
            : base(repository, logger) { }
    }
}
