using Project.Business.Mediators.Interfaces;
using Project.DataAccess.Entities.Concretes;

namespace Project.Business.Mediators.Concretes.Careers.Put
{
    public class PutCareer : IBaseEntityRequest<Career>
    {
        public Career Entity { get; set; } = new Career();
    }
}
