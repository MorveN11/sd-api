using MediatR;
using Project.DataAccess.Entities.Concretes;
using Project.DataAccess.Repositories.Interfaces;

namespace Project.Business.Students.Get
{
    public class GetStudentCareersHandler : IRequestHandler<GetStudentCareers, IList<Career>>
    {
        private readonly IStudentRepository _repository;

        public GetStudentCareersHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<Career>> Handle(
            GetStudentCareers request,
            CancellationToken cancellationToken
        )
        {
            var careers = await _repository.GetCareers(request.StudentId);

            return careers;
        }
    }
}
