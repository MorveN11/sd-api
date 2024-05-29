using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Api
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            Expression<Func<Student, bool>> lambda = student => true;
            var students = await _studentRepository.Read(lambda);

            return Ok(students);
        }
    }
}
