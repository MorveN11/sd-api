using Project.Business.Mediators.Interfaces;
using Project.DataAccess.Entities.Concretes;

namespace Project.Business.Mediators.Concretes.Careers.Post
{
    public class PostCareer : IBaseEntityRequest<Career>
    {
        public Career Entity { get; set; } = new Career();
    }
}
