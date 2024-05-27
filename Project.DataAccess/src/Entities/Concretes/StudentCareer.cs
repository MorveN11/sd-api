namespace Project.DataAccess.Entities.Concretes
{
    public class StudentCareer
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; } = new Student();

        public Guid CareerId { get; set; }
        public Career Career { get; set; } = new Career();
    }
}
