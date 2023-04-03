using AutoMapper;
using MongoDB.Driver;
using XMLApp.DTO;
using XMLApp.Exceptions;
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
            Ticket ticket = await _ticketRepository.FindByIdAsync(ticketPurchase.Flight.TicketId);
            if (ticket.Quantity >= ticketPurchaseDTO.NumOfPassengers)
                ticket.Quantity -= ticketPurchaseDTO.NumOfPassengers;
            else
                throw new NotAvailableException("Tickets are not available");
            ticketPurchase.Ticket = ticket;
            ticketPurchase.TotalPrice = ticketPurchase.Ticket.Price * ticketPurchaseDTO.NumOfPassengers;
            await Update(ticketPurchase.Flight.TicketId, ticket);
            await _ticketPurchaseHistoryRepositry.InsertOneAsync(ticketPurchase);
        }

        public async Task Delete(string id)
        {
            await _ticketRepository.DeleteByIdAsync(id);
        }

        public List<PurchasedTicketDTO> GetPurchasedTickets(string userId)
        {
            List<TicketPurchaseHistory> ticketPurchaseHistories = _ticketPurchaseHistoryRepositry.FilterBy(t => t.User.Id.ToString().Equals(userId)).ToList();
            var purchasesDTO = _mapper.Map<List<PurchasedTicketDTO>>(ticketPurchaseHistories);
            return purchasesDTO;

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
