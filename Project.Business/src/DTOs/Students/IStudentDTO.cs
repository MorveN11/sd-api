namespace Project.Business.DTOs.Students
{
    public interface IStudentDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
