using Project.DataAccess.Entities.Interfaces;

namespace Project.DataAccess.Entities.Concretes
{
    public class Career : IBaseEntityRelation<Student>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public IList<Student> Relations { get; set; } = [];
    }
}
