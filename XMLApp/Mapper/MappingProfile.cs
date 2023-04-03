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
            CreateMap<TicketPurchaseHistory, TicketPurchaseDTO>().ReverseMap();
            CreateMap<TicketPurchaseHistory, PurchasedTicketDTO>().ForMember(o => o.TicketQuantity, p => p.MapFrom(src => src.Ticket.Quantity))
                                                                  .ForMember(o => o.TicketFullPrice, p => p.MapFrom(src => src.Ticket.Price))
                                                                  .ForMember(o => o.TicketPrice, p => p.MapFrom(src => src.Ticket.Price))
                                                                  .ForMember(o => o.TakeOffCity, p => p.MapFrom(src => src.Flight.TakeOffLocation.City))
                                                                  .ForMember(o => o.TakeOffDate, p => p.MapFrom(src => src.Flight.TakeOffDate))
                                                                  .ForMember(o => o.LandingCity, p => p.MapFrom(src => src.Flight.LandingLocation.City))
                                                                  .ForMember(o => o.FlightId, p => p.MapFrom(src => src.Flight.Id.ToString()))
                                                                  .ForMember(o => o.LandingDate, p => p.MapFrom(src => src.Flight.LandingDate));
        }
    }
}

