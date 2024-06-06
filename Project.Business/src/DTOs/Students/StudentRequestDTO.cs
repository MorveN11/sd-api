namespace Project.Business.DTOs.Students
{
    public class StudentRequestDTO : IBaseEntityRequestDTO, IStudentDTO
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
