using AutoMapper;
using XMLApp.DTO;
using XMLApp.Model;

namespace XMLApp.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Flight, NewFlightDTO>().ReverseMap();
            CreateMap<Ticket, NewFlightDTO>().ReverseMap();
            CreateMap<RegisterDTO, User>();
            CreateMap<User, RegisterDTO>();
        }
    }
}

