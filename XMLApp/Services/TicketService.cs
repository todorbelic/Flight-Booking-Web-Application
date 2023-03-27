using MongoDB.Driver;
using XMLApp.Model;

namespace XMLApp.Services
{
    public class TicketService: ITicketService
    {
        private readonly IMongoCollection<Ticket> _tickets;
        public TicketService()
        {

            var settings = MongoClientSettings.FromConnectionString("mongodb://xws:gKz8dx3HFljTqsee@ac-bxlowrt-shard-00-00.jzm0jin.mongodb.net:27017,ac-bxlowrt-shard-00-01.jzm0jin.mongodb.net:27017,ac-bxlowrt-shard-00-02.jzm0jin.mongodb.net:27017/?ssl=true&replicaSet=atlas-8liqmh-shard-0&authSource=admin&retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("TicketDB");
        }

        public List<Ticket> Get() => _tickets.Find(ticket => true).ToList();

        public Ticket Get(int id) => _tickets.Find(ticket => ticket.Id == id).FirstOrDefault();

        public Ticket Create(Ticket ticket)
        {
            _tickets.InsertOne(ticket);
            return ticket;
        }

        public void Update(int id, Ticket updatedTicket) => _tickets.ReplaceOne(game => game.Id == id, updatedTicket);

        public void Delete(Ticket ticketToDelete) => _tickets.DeleteOne(game => game.Id == ticketToDelete.Id);

        public void Delete(int id) => _tickets.DeleteOne(ticket => ticket.Id == id);
    }
}
