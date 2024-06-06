using Project.Business.Mediators.Interfaces;

namespace Project.Business.Mediators.Concretes.StudentsCareers.Post
{
    public class PostStudentCareerById : IBaseRelationRequest
    {
        public Guid FirstId { get; set; }
        public Guid SecondId { get; set; }
    }
}
