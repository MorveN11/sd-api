using Project.Business.Mediators.Concretes.Bases;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.Careers.Put
{
    public class PutCareerHandler : BasePutEntityHandler<Career, PutCareer, ICareerRepository>
    {
        public PutCareerHandler(ICareerRepository repository, LogHandler logger)
            : base(repository, logger) { }
    }
}
