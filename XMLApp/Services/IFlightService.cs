using XMLApp.DTO;
using XMLApp.Model;

namespace XMLApp.Services
{
    public interface IFlightService
    {
        public List<Flight> Get();
        public Task<Flight> GetById(string id);

        public Task<Flight> Create(NewFlightDTO flight);

        public Task Update(string id, Flight updatedFlight);
        public Task Delete(string id);
    }
}
