using Microsoft.AspNetCore.Mvc;
using Project.Business.DTOs;
using Project.Business.Mediators.Interfaces;
using Project.DataAccess.Entities.Interfaces;

namespace Project.Api.Controllers.Interfaces
{
    public interface IBaseController<TEntity, TRequest, TResponse, TCreate, TRead, TUpdate, TDelete>
        where TEntity : class, IBaseEntity, new()
        where TRequest : class, IBaseEntityRequestDTO, new()
        where TResponse : class, IBaseEntityResponseDTO, new()
        where TCreate : class, IBaseEntityRequest<TEntity>, new()
        where TRead : class, IBaseIdRequest<TEntity>, new()
        where TUpdate : class, IBaseEntityRequest<TEntity>, new()
        where TDelete : class, IBaseIdBoolRequest, new()
    {
        Task<IActionResult> PostEntity(TRequest entityDTO);

        Task<IActionResult> GetEntityById(Guid id);

        Task<IActionResult> PutEntity(Guid id, TRequest entityDTO);

        Task<IActionResult> DeleteEntityById(Guid id);
    }
}
