using MongoDB.Driver;
using XMLApp.Model;

namespace XMLApp.Services
{
    public class FlightService : IFlightService

    {

        private readonly IMongoCollection<Flight> _flights;
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
