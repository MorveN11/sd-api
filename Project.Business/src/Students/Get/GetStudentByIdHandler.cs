using MediatR;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Students.Get
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentById, Student>
    {
        private readonly IStudentRepository _repository;

        public GetStudentByIdHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Student> Handle(
            GetStudentById request,
            CancellationToken cancellationToken
        )
        {
            var student = await _repository.GetById(request.StudentId);

            return student;
        }
    }
}
