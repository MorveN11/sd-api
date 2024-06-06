namespace Project.Business.DTOs.Careers
{
    public class CareerResponseDTO : IBaseEntityResponseDTO, ICareerDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
