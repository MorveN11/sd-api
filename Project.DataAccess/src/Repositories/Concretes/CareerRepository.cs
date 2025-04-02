using Project.DataAccess.Context;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;
using Project.DataAccess.Services;

namespace Project.DataAccess.Repositories.Concretes
{
    public class CareerRepository : BaseEntityRelationRepository<Career, Student>, ICareerRepository
    {
        public CareerRepository(ICachingService cachingService, IApplicationDbContext context)
            : base(cachingService, context) { }
    }
}
