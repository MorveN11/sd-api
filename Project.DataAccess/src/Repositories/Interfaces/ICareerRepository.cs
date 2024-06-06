using Project.DataAccess.Entities.Concretes;

namespace Project.DataAccess.Repositories.Interfaces
{
    public interface ICareerRepository : IBaseEntityRelationRepository<Career, Student> { }
}
