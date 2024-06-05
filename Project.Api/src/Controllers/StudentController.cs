using System.ComponentModel.DataAnnotations;
using AutoMapper;
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

        public StudentController(IMediator mediator, IMapper mapper, LogHandler logger)
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

            return Ok(student);
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

            Console.WriteLine($"Response: {response}");
            return response switch
            {
                > 0 => Ok(),
                _ => BadRequest()
            };
        }

        [HttpPost("{student}")]
        public async Task<IActionResult> PostStudent([Required] Student student)
        {
            var contract = new PostStudent(student);
            var reponse = await _mediator.Send(contract);

            return reponse switch
            {
                > 0 => Ok(),
                _ => BadRequest()
            };
        }

        [HttpPut("{student}")]
        public async Task<IActionResult> PutStudent([Required] Student student)
        {
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
