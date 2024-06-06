using Project.Business.Mediators.Concretes.Bases;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.Careers.Delete
{
    public class DeleteCareerByIdHandler
        : BaseDeleteEntityByIdHandler<Career, DeleteCareerById, ICareerRepository>
    {
        public DeleteCareerByIdHandler(ICareerRepository repository, LogHandler logger)
            : base(repository, logger) { }
    }
}
