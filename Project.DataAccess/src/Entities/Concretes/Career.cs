using Project.DataAccess.Entities.Interfaces;

namespace Project.DataAccess.Entities.Concretes
{
    public class Career : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public List<StudentCareer> StudentCareers { get; set; } = new List<StudentCareer>();
    }
}
