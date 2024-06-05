using MediatR;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Students.Put
{
    public class PutStudentHandler : IRequestHandler<PutStudent, int>
    {
        private readonly IStudentRepository _repository;

        public PutStudentHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(PutStudent request, CancellationToken cancellationToken)
        {
            return await _repository.Update(request.Student);
        }
    }
}
