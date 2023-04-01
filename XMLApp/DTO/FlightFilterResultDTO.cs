using XMLApp.Model;

namespace XMLApp.DTO
{
    public class FlightFilterResultDTO
    {
        public DateTime TakeOffDate { get; set; }
        public string TakeOffCountry { get; set; }
        public string TakeOffCity { get; set; }
        public string LandingCountry { get; set; }
        public string LandingCity { get; set; }
        public double TicketPricePerPassenger { get; set; }
        public double TicketPriceTotal { get; set; }
        public string TicketId { get; set; }
        public string FlightId { get; set; }
        
        public FlightFilterResultDTO(Flight flight, Ticket ticket, int passengersCount)
        {
            TakeOffDate = flight.TakeOffDate;
            TakeOffCountry = flight.TakeOffLocation.Country;
            TakeOffCity = flight.TakeOffLocation.City;
            LandingCountry = flight.LandingLocation.Country;
            LandingCity = flight.LandingLocation.City;
            TicketPriceTotal = passengersCount * ticket.Price;
            TicketPricePerPassenger = ticket.Price;
            TicketId = ticket.Id.ToString();
            FlightId = flight.Id.ToString();
        }
    }
}
