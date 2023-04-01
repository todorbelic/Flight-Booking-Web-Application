using AutoMapper;
using XMLApp.DTOs;
using XMLApp.Model;

namespace XMLApp.Mapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<RegisterDTO, User>();
            CreateMap<User, RegisterDTO>();
        }
    }
}
