using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Project.Core.Handlers;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Api
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly LogHandler _logger;

        public StudentController(IStudentRepository studentRepository, LogHandler logger)
        {
            _studentRepository = studentRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            int x = 0;
            int y = 0;
            int z = x / y;

            Expression<Func<Student, bool>> lambda = student => true;
            var students = await _studentRepository.Read(lambda);

            return Ok(students);
        }
    }
}
