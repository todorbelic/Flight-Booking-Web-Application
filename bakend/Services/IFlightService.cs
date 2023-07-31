using XMLApp.DTO;
using XMLApp.Model;

namespace XMLApp.Services
{
    public interface IFlightService
    {
        List<Flight> Get();
        Task<Flight> GetById(string id);
        List<FlightFilterResultDTO> GetByFilter(FlightFilterDTO filter);
        Task<Flight> Create(NewFlightDTO flight);
        Task Update(string id, Flight updatedFlight);
        Task Delete(string id);
        List<FlightFilterResultDTO> GetAvailable();
    }
}
