using System.ComponentModel.DataAnnotations;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Business.DTOs;
using Project.Business.Students.Delete;
using Project.Business.Students.Get;
using Project.Business.Students.Post;
using Project.Business.Students.Put;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Concretes;

namespace Project.Api
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly LogHandler _logger;

        public StudentController(
            IMediator mediator,
            IMapper mapper,
            IValidator<StudentDTO> validtor,
            LogHandler logger
        )
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentById([Required] Guid studentId)
        {
            var contract = new GetStudentById(studentId);
            var student = await _mediator.Send(contract);
            var response = _mapper.Map<StudentDTO>(student);

            return Ok(response);
        }

        [HttpGet(), Route("careers/{studentId}")]
        public async Task<IActionResult> GetStudentCareersById([Required] Guid studentId)
        {
            var contract = new GetStudentCareers(studentId);

            var model = await _mediator.Send(contract);
            var careers = _mapper.Map<IList<CareerDTO>>(model);

            return Ok(careers);
        }

        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudentById([Required] Guid studentId)
        {
            var contract = new DeleteStudentById(studentId);
            var response = await _mediator.Send(contract);

            return response switch
            {
                > 0 => Ok(),
                _ => BadRequest()
            };
        }

        [HttpPost()]
        public async Task<IActionResult> PostStudent([FromBody] StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = _mapper.Map<Student>(studentDTO);

            var contract = new PostStudent(student);
            var reponse = await _mediator.Send(contract);

            return reponse switch
            {
                > 0 => Ok(),
                _ => BadRequest()
            };
        }

        [HttpPut()]
        public async Task<IActionResult> PutStudent([FromBody] StudentDTO studentDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = _mapper.Map<Student>(studentDTO);

            var contract = new PutStudent(student);
            var response = await _mediator.Send(contract);

            return response switch
            {
                > 0 => Ok(),
                _ => BadRequest()
            };
        }
    }
}
