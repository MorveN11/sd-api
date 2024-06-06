using Microsoft.AspNetCore.Mvc;
using Project.Business.Mediators.Interfaces;
using Project.DataAccess.Entities.Interfaces;

namespace Project.Api.Controllers.Interfaces
{
    public interface IBaseRelationController<TFirstEntity, TSecondEntity, TCreate, TDelete>
        where TFirstEntity : class, IBaseEntityRelation<TSecondEntity>, new()
        where TSecondEntity : class, IBaseEntityRelation<TFirstEntity>, new()
        where TCreate : class, IBaseRelationRequest, new()
        where TDelete : class, IBaseRelationRequest, new()
    {
        Task<ActionResult> Create(Guid firstEntityId, Guid secondEntityId);
        Task<ActionResult> Delete(Guid firstEntityId, Guid secondEntityId);
    }
}
