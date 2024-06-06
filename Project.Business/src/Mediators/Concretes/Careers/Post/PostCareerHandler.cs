using Project.Business.Mediators.Concretes.Bases;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Mediators.Concretes.Careers.Post
{
    public class PostCareerHandler : BasePostEntityHandler<Career, PostCareer, ICareerRepository>
    {
        public PostCareerHandler(ICareerRepository repository, LogHandler logger)
            : base(repository, logger) { }
    }
}
