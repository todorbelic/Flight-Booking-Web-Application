using XMLApp.Model;

namespace XMLApp.DTO
{
    public class FlightFilterResultDTO
    {
        public string TakeOffDate { get; set; }
        public string TakeOffCountry { get; set; }
        public string TakeOffCity { get; set; }
        public string LandingDate { get; set; }
        public string LandingCountry { get; set; }
        public string LandingCity { get; set; }
        public int TicketNumber { get; set; }
        public double TicketPricePerPassenger { get; set; }
        public double TicketPriceTotal { get; set; }
        public string TicketId { get; set; }
        public string FlightId { get; set; }
        
        public FlightFilterResultDTO(Flight flight, Ticket ticket, int passengersCount)
        {
            TakeOffDate = flight.TakeOffDate.ToShortDateString()+" "+flight.TakeOffDate.ToShortTimeString();
            TakeOffCountry = flight.TakeOffLocation.Country;
            TakeOffCity = flight.TakeOffLocation.City;
            LandingDate = flight.LandingDate.ToShortDateString() + " " + flight.LandingDate.ToShortTimeString();
            LandingCountry = flight.LandingLocation.Country;
            LandingCity = flight.LandingLocation.City;
            TicketPriceTotal = passengersCount * ticket.Price;
            TicketPricePerPassenger = ticket.Price;
            TicketId = ticket.Id.ToString();
            FlightId = flight.Id.ToString();
            TicketNumber= ticket.Quantity;
        }
    }
}
