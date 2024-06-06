using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Controllers.Interfaces;
using Project.Business.Mediators.Interfaces;
using Project.Core.Responses;
using Project.DataAccess.Entities.Interfaces;

namespace Project.Api.Controllers.Concretes
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseRelationController<TFirstEntity, TSecondEntity, TCreate, TDelete>
        : ControllerBase,
            IBaseRelationController<TFirstEntity, TSecondEntity, TCreate, TDelete>
        where TFirstEntity : class, IBaseEntityRelation<TSecondEntity>, new()
        where TSecondEntity : class, IBaseEntityRelation<TFirstEntity>, new()
        where TCreate : class, IBaseRelationRequest, new()
        where TDelete : class, IBaseRelationRequest, new()
    {
        protected readonly IMediator Mediator;

        protected BaseRelationController(IMediator mediator, IMapper mapper)
        {
            Mediator = mediator;
        }

        [HttpPost("{firstId}/{secondId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SucessfullResponse), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [ProducesResponseType(typeof(ExceptionResponse), 404)]
        [ProducesResponseType(typeof(ExceptionResponse), 409)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<ActionResult> Create(
            [FromRoute] [Required] Guid firstId,
            [FromRoute] [Required] Guid secondId
        )
        {
            var contract = new TCreate { FirstId = firstId, SecondId = secondId };
            await Mediator.Send(contract);

            return Ok(new SucessfullResponse("Relation created successfully."));
        }

        [HttpDelete("{firstId}/{secondId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SucessfullResponse), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [ProducesResponseType(typeof(ExceptionResponse), 404)]
        [ProducesResponseType(typeof(ExceptionResponse), 409)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<ActionResult> Delete(
            [FromRoute] [Required] Guid firstId,
            [FromRoute] [Required] Guid secondId
        )
        {
            var contract = new TDelete { FirstId = firstId, SecondId = secondId };

            await Mediator.Send(contract);

            return Ok(new SucessfullResponse("Relation deleted successfully."));
        }
    }
}
