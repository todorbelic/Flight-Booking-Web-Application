using AutoMapper;
using MongoDB.Driver;
using XMLApp.DTO;
using XMLApp.Model;
using XMLApp.Repository;

namespace XMLApp.Services
{
    public class TicketService: ITicketService
    {
        private readonly IRepository<Ticket> _ticketRepository;
        private readonly IRepository<TicketPurchaseHistory> _ticketPurchaseHistoryRepositry;
        private readonly IFlightService _flightService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public TicketService(IRepository<Ticket> ticketRepository, IRepository<TicketPurchaseHistory> ticketPurchaseRepository, IFlightService flightService, IUserService userService, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _flightService = flightService;
            _userService = userService;
            _ticketPurchaseHistoryRepositry = ticketPurchaseRepository;
            _mapper = mapper;
        }

        public async Task<Ticket> Create(Ticket ticket)
        {
            return await _ticketRepository.InsertOneAsync(ticket);
        }

        public async Task PurchaseTicket(TicketPurchaseDTO ticketPurchaseDTO, string userId)
        {
            var ticketPurchase = _mapper.Map<TicketPurchaseHistory>(ticketPurchaseDTO);
            ticketPurchase.User = await _userService.GetById(userId);
            ticketPurchase.Flight = await _flightService.GetById(ticketPurchaseDTO.FlightId);
            ticketPurchase.Ticket = await _ticketRepository.FindByIdAsync(ticketPurchase.Flight.TicketId);
            ticketPurchase.TotalPrice = ticketPurchase.Ticket.Price * ticketPurchaseDTO.NumOfPassengers;
            await _ticketPurchaseHistoryRepositry.InsertOneAsync(ticketPurchase);
        }

        public async Task Delete(string id)
        {
            await _ticketRepository.DeleteByIdAsync(id);
        }

        public List<Ticket> Get()
        {
            return _ticketRepository.AsQueryable().ToList();
        }

        public async Task<Ticket> GetById(string id)
        {
            return await _ticketRepository.FindByIdAsync(id);
        }

        public async Task Update(string id, Ticket updatedTicket)
        {
            await _ticketRepository.ReplaceOneAsync(updatedTicket);
        }
    }
}
