using System.Linq.Expressions;
using Project.DataAccess.Entities.Interfaces;

namespace Project.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<T> : IDisposable
        where T : class, IBaseEntity, new()
    {
        Task<int> Create(T entity);
        Task<int> Update(T entity);
        Task<int> Delete(T entity);
        Task<IList<T>> Read(Expression<Func<T, bool>> lambda);
        Task<T> GetById(Guid id);
    }
}
