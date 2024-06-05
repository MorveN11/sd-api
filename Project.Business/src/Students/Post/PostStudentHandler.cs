using MediatR;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Students.Post
{
    public class PostStudentHandler : IRequestHandler<PostStudent, int>
    {
        private readonly IStudentRepository _repository;

        public PostStudentHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(PostStudent request, CancellationToken cancellationToken)
        {
            return await _repository.Create(request.Student);
        }
    }
}
