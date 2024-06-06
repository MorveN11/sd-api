using Project.DataAccess.Context;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.DataAccess.Repositories.Concretes
{
    public class CareerRepository : BaseEntityRelationRepository<Career, Student>, ICareerRepository
    {
        public CareerRepository(PostgresContext context)
            : base(context) { }
    }
}
