namespace Project.Business.DTOs.Careers
{
    public class CareerRequestDTO : IBaseEntityRequestDTO, ICareerDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
