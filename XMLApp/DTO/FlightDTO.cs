using XMLApp.Model;

namespace XMLApp.DTO
{
    public class FlightDTO
    {
        public string TakeoffCity{ get; set; }
        public string LandingCity { get; set; }
        public string TakeoffTime { get; set; }
        public string LandingTime{ get; set; }
        public FlightDTO(Flight flight)
        {
            TakeoffCity = flight.TakeOffLocation.City;
            LandingCity = flight.LandingLocation.City;
            TakeoffTime=flight.TakeOffDate.Date.Date.ToString()+" "+flight.TakeOffDate.Date.TimeOfDay.ToString();
            LandingTime = flight.LandingDate.Date.Date.ToString() + " " + flight.LandingDate.Date.TimeOfDay.ToString();

        }
    }
}
