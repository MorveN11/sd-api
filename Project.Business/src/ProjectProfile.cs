using AutoMapper;
using Project.Business.DTOs;
using Project.DataAccess.Entities.Concretes;

namespace Project.Business
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<Career, CareerDTO>();
        }
    }
}
