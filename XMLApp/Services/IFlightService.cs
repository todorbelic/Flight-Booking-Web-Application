using XMLApp.Model;

namespace XMLApp.Services
{
    public interface IFlightService
    {
        public List<Flight> Get();
        public Flight GetById(int id);

        public Flight Create(Flight flight);

        public void Update(int id, Flight updatedFlight);
        public void Delete(int id);
        public void Delete(Flight flightToDelete);
    }
}
