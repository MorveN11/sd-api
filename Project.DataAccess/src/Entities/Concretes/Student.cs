using Project.DataAccess.Entities.Interfaces;

namespace Project.DataAccess.Entities.Concretes
{
    public class Student : IBaseEntityRelation<Career>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public IList<Career> Relations { get; set; } = [];
    }
}
