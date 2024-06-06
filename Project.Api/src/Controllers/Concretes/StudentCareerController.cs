using AutoMapper;
using MediatR;
using Project.Business.Mediators.Concretes.StudentsCareers.Delete;
using Project.Business.Mediators.Concretes.StudentsCareers.Post;
using Project.DataAccess.Entities.Concretes;

namespace Project.Api.Controllers.Concretes
{
    public class StudentCareerController
        : BaseRelationController<Student, Career, PostStudentCareerById, DeleteStudentCareerById>
    {
        public StudentCareerController(IMediator mediator, IMapper mapper)
            : base(mediator, mapper) { }
    }
}
