using AutoMapper;
using Project.Business.DTOs.Careers;
using Project.Business.DTOs.Students;
using Project.DataAccess.Entities.Concretes;

namespace Project.Business
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Student, StudentResponseDTO>();
            CreateMap<StudentRequestDTO, Student>();
            CreateMap<Career, CareerResponseDTO>();
            CreateMap<CareerRequestDTO, Career>();
        }
    }
}
