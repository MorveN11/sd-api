using Project.Business.Mediators.Interfaces;

namespace Project.Business.Mediators.Concretes.StudentsCareers.Delete
{
    public class DeleteStudentCareerById : IBaseRelationRequest
    {
        public Guid FirstId { get; set; }
        public Guid SecondId { get; set; }
    }
}
