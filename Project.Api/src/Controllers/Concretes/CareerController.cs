using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Business.DTOs.Careers;
using Project.Business.DTOs.Students;
using Project.Business.Mediators.Concretes.Careers.Delete;
using Project.Business.Mediators.Concretes.Careers.Get;
using Project.Business.Mediators.Concretes.Careers.Post;
using Project.Business.Mediators.Concretes.Careers.Put;
using Project.Core.Responses;
using Project.DataAccess.Entities.Concretes;

namespace Project.Api.Controllers.Concretes
{
    public class CareerController
        : BaseController<
            Career,
            CareerRequestDTO,
            CareerResponseDTO,
            PostCareer,
            GetCareerById,
            PutCareer,
            DeleteCareerById
        >
    {
        public CareerController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper) { }

        [ProducesResponseType(typeof(SucessfullDataResponse<CareerResponseDTO>), 200)]
        public override async Task<IActionResult> PostEntity(CareerRequestDTO entityDTO)
        {
            return await base.PostEntity(entityDTO);
        }

        [ProducesResponseType(typeof(SucessfullDataResponse<CareerResponseDTO>), 200)]
        public override async Task<IActionResult> GetEntityById(Guid id)
        {
            return await base.GetEntityById(id);
        }

        [ProducesResponseType(typeof(SucessfullDataResponse<CareerResponseDTO>), 200)]
        public override async Task<IActionResult> PutEntity(Guid id, CareerRequestDTO entityDTO)
        {
            return await base.PutEntity(id, entityDTO);
        }

        [HttpGet(), Route("students/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SucessfullDataResponse<IList<StudentResponseDTO>>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [ProducesResponseType(typeof(ExceptionResponse), 404)]
        [ProducesResponseType(typeof(ExceptionResponse), 409)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> GetStudentCareers([FromRoute] [Required] Guid id)
        {
            var contract = new GetCareerStudents { Id = id };
            var mediatorResponse = await Mediator.Send(contract);

            var response = Mapper.Map<IList<StudentResponseDTO>>(mediatorResponse);

            return Ok(
                new SucessfullDataResponse<IList<StudentResponseDTO>>(
                    response,
                    "Students retrieved successfully."
                )
            );
        }
    }
}
