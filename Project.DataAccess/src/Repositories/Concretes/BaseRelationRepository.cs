using Microsoft.EntityFrameworkCore;
using Project.DataAccess.Context;
using Project.DataAccess.Entities.Interfaces;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.DataAccess.Repositories.Concretes
{
    public abstract class BaseRelationRepository<TFirstEntity, TSecondEntity>
        : IBaseRelationRepository<TFirstEntity, TSecondEntity>
        where TFirstEntity : class, IBaseEntityRelation<TSecondEntity>, new()
        where TSecondEntity : class, IBaseEntityRelation<TFirstEntity>, new()
    {
        protected readonly IApplicationDbContext Context;

        protected BaseRelationRepository(IApplicationDbContext context)
        {
            Context = context;
        }

        public async Task<(
            TFirstEntity? FirstEntity,
            TSecondEntity? SecondEntity,
            int Status
        )?> CheckExists(Guid firstEntityId, Guid secondEntityId)
        {
            var firstEntity = await Context
                .Set<TFirstEntity>()
                .Include(s => s.Relations)
                .FirstOrDefaultAsync(s => s.Id.Equals(firstEntityId));

            var secondEntity = await Context
                .Set<TSecondEntity>()
                .Include(c => c.Relations)
                .FirstOrDefaultAsync(c => c.Id.Equals(secondEntityId));

            if (firstEntity == null || secondEntity == null)
            {
                return (FirstEntity: null, SecondEntity: null, Status: 404);
            }

            return (FirstEntity: firstEntity, SecondEntity: secondEntity, Status: 200);
        }

        public async Task<(
            TFirstEntity? FirstEntity,
            TSecondEntity? SecondEntity,
            int Status
        )?> CheckRelation(Guid firstEntityId, Guid secondEntityId)
        {
            var response = await CheckExists(firstEntityId, secondEntityId);

            var status = response.Value.Status;
            var firstEntity = response.Value.FirstEntity;
            var secondEntity = response.Value.SecondEntity;

            if (firstEntity == null || secondEntity == null)
            {
                return (FirstEntity: null, SecondEntity: null, Status: status);
            }

            var firstContainsSecond = firstEntity.Relations.Any(c => c.Id.Equals(secondEntityId));
            var secondContainsFirst = secondEntity.Relations.Any(s => s.Id.Equals(firstEntityId));

            if (firstContainsSecond && secondContainsFirst)
            {
                return (FirstEntity: null, SecondEntity: null, Status: 409);
            }

            return (FirstEntity: firstEntity, SecondEntity: secondEntity, Status: 200);
        }

        public async Task<int> AddRelation(Guid firstEntityId, Guid secondEntityId)
        {
            var relation = await CheckRelation(firstEntityId, secondEntityId);

            var firstEntity = relation.Value.FirstEntity;
            var secondEntity = relation.Value.SecondEntity;
            var status = relation.Value.Status;

            if (firstEntity == null || secondEntity == null)
            {
                return status;
            }

            firstEntity.Relations.Add(secondEntity);
            secondEntity.Relations.Add(firstEntity);

            await Context.SaveChangesAsync();

            return status;
        }

        public async Task<int> RemoveRelation(Guid firstEntityId, Guid secondEntityId)
        {
            var relation = await CheckExists(firstEntityId, secondEntityId);

            var firstEntity = relation.Value.FirstEntity;
            var secondEntity = relation.Value.SecondEntity;
            var status = relation.Value.Status;

            if (firstEntity == null || secondEntity == null)
            {
                return status;
            }

            firstEntity.Relations.Remove(secondEntity);
            secondEntity.Relations.Remove(firstEntity);

            await Context.SaveChangesAsync();

            return status;
        }
    }
}
