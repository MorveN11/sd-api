namespace Api.Entities
{
    public class Student : IBaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public List<Career> Careers { get; set; } = new List<Career>();
    }
}
