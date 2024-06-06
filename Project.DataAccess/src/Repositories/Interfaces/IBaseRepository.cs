using Project.DataAccess.Entities.Interfaces;

namespace Project.DataAccess.Repositories.Interfaces
{
    public interface IBaseRepository<T> : IDisposable
        where T : class, IBaseEntity, new()
    {
        Task<T?> Create(T entity);
        Task<T?> GetById(Guid id);
        Task<T?> Update(T entity);
        Task<bool> Delete(T entity);
        Task<bool> Exists(Guid id);
    }
}
