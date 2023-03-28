using MongoDB.Driver;
using XMLApp.Model;

namespace XMLApp.Services
{
    public class FlightService : IFlightService

    {

        private readonly IMongoCollection<Flight> _flights;

        public FlightService()
        {
            var settings = MongoClientSettings.FromConnectionString("mongodb://xws:gKz8dx3HFljTqsee@ac-bxlowrt-shard-00-00.jzm0jin.mongodb.net:27017,ac-bxlowrt-shard-00-01.jzm0jin.mongodb.net:27017,ac-bxlowrt-shard-00-02.jzm0jin.mongodb.net:27017/?ssl=true&replicaSet=atlas-8liqmh-shard-0&authSource=admin&retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("FlightDB");

            _flights = database.GetCollection<Flight>("Flights");
            //Ticket ticket = new Ticket { Price = 3213 };

            // Inserting the first document will create collection named "Games"
            //_tickets.InsertOne(ticket);
        }
        public Flight Create(Flight flight)
        {
            _flights.InsertOne(flight);
            return flight;
        }

        public void Delete(int id) => _flights.DeleteOne(flight => flight.Id == id);
    
        public void Delete(Flight flightToDelete) => _flights.DeleteOne(flight => flight.Id == flightToDelete.Id);

        public List<Flight> Get() => _flights.Find(flight => true).ToList();

        public Flight GetById(int id) => _flights.Find(flight => flight.Id == id).FirstOrDefault();


        public void Update(int id, Flight updatedFlight) => _flights.ReplaceOne(flight => flight.Id == id, updatedFlight);
    }
}
