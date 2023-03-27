using XMLApp.Model;

namespace XMLApp.Services
{
    public interface ITicketService
    {
        public List<Ticket> Get();
        public Ticket Get(int id);
        public Ticket Create(Ticket ticket);
        public void Update(int id, Ticket updatedTicket);
        public void Delete(Ticket ticketToDelete);
        public void Delete(int id);


    }
}
