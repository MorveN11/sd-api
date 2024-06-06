namespace Project.Business.DTOs.Students
{
    public class StudentResponseDTO : IBaseEntityResponseDTO, IStudentDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
