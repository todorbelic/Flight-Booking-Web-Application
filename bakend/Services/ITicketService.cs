using XMLApp.DTO;
using XMLApp.Model;

namespace XMLApp.Services
{
    public interface ITicketService
    {
        public List<Ticket> Get();
        public Task<Ticket> GetById(string id);

        public Task<Ticket> Create(Ticket ticket);
        public Task PurchaseTicket(TicketPurchaseDTO ticketPurchaseDTO, string userId);
        public List<PurchasedTicketDTO> GetPurchasedTickets(string userId);
        public Task Update(string id, Ticket updatedTicket);
        public Task Delete(string id);


    }
}
