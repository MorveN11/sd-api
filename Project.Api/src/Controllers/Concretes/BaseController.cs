using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Api.Controllers.Interfaces;
using Project.Business.DTOs;
using Project.Business.Mediators.Interfaces;
using Project.Core.Responses;
using Project.DataAccess.Entities.Interfaces;

namespace Project.Api.Controllers.Concretes
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController<
        TEntity,
        TRequest,
        TResponse,
        TCreate,
        TRead,
        TUpdate,
        TDelete
    >
        : ControllerBase,
            IBaseController<TEntity, TRequest, TResponse, TCreate, TRead, TUpdate, TDelete>
        where TEntity : class, IBaseEntity, new()
        where TRequest : class, IBaseEntityRequestDTO, new()
        where TResponse : class, IBaseEntityResponseDTO, new()
        where TCreate : class, IBaseEntityRequest<TEntity>, new()
        where TRead : class, IBaseIdRequest<TEntity>, new()
        where TUpdate : class, IBaseEntityRequest<TEntity>, new()
        where TDelete : class, IBaseIdBoolRequest, new()
    {
        protected readonly IMediator Mediator;
        protected readonly IMapper Mapper;

        protected BaseController(IMediator mediator, IMapper mapper)
        {
            Mediator = mediator;
            Mapper = mapper;
        }

        [HttpPost()]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [ProducesResponseType(typeof(ExceptionResponse), 404)]
        [ProducesResponseType(typeof(ExceptionResponse), 409)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public virtual async Task<IActionResult> PostEntity([FromBody] TRequest entityDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedEntity = Mapper.Map<TEntity>(entityDTO);

            var contract = new TCreate { Entity = mappedEntity };
            var mediatorResponse = await Mediator.Send(contract);

            var response = Mapper.Map<TResponse>(mediatorResponse);

            return Ok(
                new SucessfullDataResponse<TResponse>(
                    response,
                    $"{typeof(TEntity).Name} created successfully."
                )
            );
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [ProducesResponseType(typeof(ExceptionResponse), 404)]
        [ProducesResponseType(typeof(ExceptionResponse), 409)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public virtual async Task<IActionResult> GetEntityById([FromRoute] [Required] Guid id)
        {
            var contract = new TRead { Id = id };
            var mediatorResponse = await Mediator.Send(contract);

            var response = Mapper.Map<TResponse>(mediatorResponse);

            return Ok(
                new SucessfullDataResponse<TResponse>(
                    response,
                    $"{typeof(TEntity).Name} retrieved successfully."
                )
            );
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [ProducesResponseType(typeof(ExceptionResponse), 404)]
        [ProducesResponseType(typeof(ExceptionResponse), 409)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public virtual async Task<IActionResult> PutEntity(
            [FromRoute] [Required] Guid id,
            [FromBody] TRequest entityDTO
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var mappedEntity = Mapper.Map<TEntity>(entityDTO);
            mappedEntity.Id = id;

            var contract = new TUpdate { Entity = mappedEntity };
            var mediatorResponse = await Mediator.Send(contract);

            var response = Mapper.Map<TResponse>(mediatorResponse);

            return Ok(
                new SucessfullDataResponse<TResponse>(
                    response,
                    $"{typeof(TEntity).Name} updated successfully."
                )
            );
        }

        [HttpDelete("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(SucessfullResponse), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [ProducesResponseType(typeof(ExceptionResponse), 404)]
        [ProducesResponseType(typeof(ExceptionResponse), 409)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public virtual async Task<IActionResult> DeleteEntityById([FromRoute] [Required] Guid id)
        {
            var contract = new TDelete { Id = id };
            await Mediator.Send(contract);

            return Ok(new SucessfullResponse($"{typeof(TEntity).Name} deleted successfully."));
        }
    }
}
