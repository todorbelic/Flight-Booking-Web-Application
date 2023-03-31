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

        public TicketService(IRepository<Flight> flightRepository, IRepository<Ticket> ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task<Ticket> Create(Ticket ticket)
        {
            return await _ticketRepository.InsertOneAsync(ticket);
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
