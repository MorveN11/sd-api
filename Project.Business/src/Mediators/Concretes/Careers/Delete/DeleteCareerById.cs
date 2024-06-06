using Project.Business.Mediators.Interfaces;

namespace Project.Business.Mediators.Concretes.Careers.Delete
{
    public class DeleteCareerById : IBaseIdBoolRequest
    {
        public Guid Id { get; set; }
    }
}
