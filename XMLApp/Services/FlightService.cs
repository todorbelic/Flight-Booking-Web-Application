using AutoMapper;
using MongoDB.Driver;
using XMLApp.DTO;
using XMLApp.Filters;
using XMLApp.Model;
using XMLApp.Repository;

namespace XMLApp.Services
{
    public class FlightService : IFlightService
    {
        private readonly IRepository<Flight> _flightRepository;
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IMapper _mapper;

        public FlightService(IRepository<Flight> flightRepository, IRepository<Ticket> ticketRepository, IMapper mapper)
        {
            _flightRepository = flightRepository;
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<Flight> Create(NewFlightDTO flightDTO)
        {
            var ticket = _mapper.Map<Ticket>(flightDTO);
            Ticket insertedTicket = await _ticketRepository.InsertOneAsync(ticket);
            var flight = _mapper.Map<Flight>(flightDTO);
            flight.Ticket = insertedTicket;
            flight.TicketId = insertedTicket.Id.ToString();
            await _flightRepository.InsertOneAsync(flight);
            return flight;
        }

        public async Task Delete(string id)
        {
            await _flightRepository.DeleteByIdAsync(id);
        }

        public List<Flight> Get()
        {
            return _flightRepository.AsQueryable().ToList();
        }

        public async Task<Flight> GetById(string id)
        {
            return await _flightRepository.FindByIdAsync(id);
        }

        public List<FlightFilterResultDTO> GetByFilter(FlightFilterDTO filter)
        {
            IEnumerable<Flight> flightsFiltered = _flightRepository.FilterBy(filter.GetFilterExpression());
            var flightsQueryable = flightsFiltered.AsQueryable();
            var ticketsQueryable = _ticketRepository.AsQueryable();
            var query = from flight in flightsQueryable
                        join ticket in ticketsQueryable on flight.TicketId equals ticket.Id.ToString()
                        where ticket.Quantity >= filter.PassengersCount
                        select new FlightFilterResultDTO(flight, ticket, filter.PassengersCount);
            return query.ToList();
        }

        public async Task Update(string id, Flight updatedFlight)
        {
            await _flightRepository.ReplaceOneAsync(updatedFlight);
        }

        public List<FlightDTO> GetAvailable()
        {
            IEnumerable<Flight> flights = Get();
            List<FlightDTO> available=new List<FlightDTO>();
            foreach (Flight flight in flights)
            {
               Ticket ticket= _ticketRepository.FindById(flight.TicketId);
                if (ticket != null && ticket.Quantity>0)
                {
                    available.Add(new FlightDTO(flight));
                }
            }

            return available;

        }
    }
}
