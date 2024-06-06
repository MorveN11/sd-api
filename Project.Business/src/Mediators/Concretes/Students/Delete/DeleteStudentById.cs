using Project.Business.Mediators.Interfaces;

namespace Project.Business.Mediators.Concretes.Students.Delete
{
    public class DeleteStudentById : IBaseIdBoolRequest
    {
        public Guid Id { get; set; }
    }
}
