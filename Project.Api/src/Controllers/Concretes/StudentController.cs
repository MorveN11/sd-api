using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Business.DTOs.Careers;
using Project.Business.DTOs.Students;
using Project.Business.Mediators.Concretes.Students.Delete;
using Project.Business.Mediators.Concretes.Students.Get;
using Project.Business.Mediators.Concretes.Students.Post;
using Project.Business.Mediators.Concretes.Students.Put;
using Project.Core.Responses;
using Project.DataAccess.Entities.Concretes;

namespace Project.Api.Controllers.Concretes
{
    public class StudentController
        : BaseController<
            Student,
            StudentRequestDTO,
            StudentResponseDTO,
            PostStudent,
            GetStudentById,
            PutStudent,
            DeleteStudentById
        >
    {
        public StudentController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper) { }

        [ProducesResponseType(typeof(SucessfullDataResponse<StudentResponseDTO>), 200)]
        public override async Task<IActionResult> PostEntity(StudentRequestDTO entityDTO)
        {
            return await base.PostEntity(entityDTO);
        }

        [ProducesResponseType(typeof(SucessfullDataResponse<StudentResponseDTO>), 200)]
        public override async Task<IActionResult> GetEntityById(Guid id)
        {
            return await base.GetEntityById(id);
        }

        [ProducesResponseType(typeof(SucessfullDataResponse<StudentResponseDTO>), 200)]
        public override async Task<IActionResult> PutEntity(Guid id, StudentRequestDTO entityDTO)
        {
            return await base.PutEntity(id, entityDTO);
        }

        [HttpGet(), Route("careers/{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SucessfullDataResponse<IList<CareerResponseDTO>>), 200)]
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [ProducesResponseType(typeof(ExceptionResponse), 404)]
        [ProducesResponseType(typeof(ExceptionResponse), 409)]
        [ProducesResponseType(typeof(ExceptionResponse), 500)]
        public async Task<IActionResult> GetStudentCareers([FromRoute] [Required] Guid id)
        {
            var contract = new GetStudentCareers { Id = id };
            var mediatorResponse = await Mediator.Send(contract);

            var response = Mapper.Map<IList<CareerResponseDTO>>(mediatorResponse);

            return Ok(
                new SucessfullDataResponse<IList<CareerResponseDTO>>(
                    response,
                    "Careers retrieved successfully."
                )
            );
        }
    }
}
