using Project.DataAccess.Entities.Interfaces;

namespace Project.DataAccess.Entities.Concretes
{
    public class Student : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public List<StudentCareer> StudentCareers { get; set; } = new List<StudentCareer>();
    }
}
