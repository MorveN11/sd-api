using MediatR;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Students.Delete
{
    public class DeleteStudentByIdHandler : IRequestHandler<DeleteStudentById, int>
    {
        private readonly IStudentRepository _repository;

        public DeleteStudentByIdHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(
            DeleteStudentById request,
            CancellationToken cancellationToken
        )
        {
            var student = await _repository.GetById(request.StudentId);

            return await _repository.Delete(student);
        }
    }
}
