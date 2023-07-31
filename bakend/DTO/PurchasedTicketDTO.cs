namespace XMLApp.DTO
{
    public class PurchasedTicketDTO
    {
        public string FlightId { get; set; }
        public int TicketQuantity { get; set; }
        public double TicketPrice { get; set; }
        public double TicketFullPrice { get; set; }
        public string TakeOffCity { get; set; }
        public string TakeOffDate { get; set; }
        public string LandingCity { get; set; }
        public string LandingDate { get; set; }

        public PurchasedTicketDTO( )
        {

        }

        
    }
}
