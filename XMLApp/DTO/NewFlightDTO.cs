using XMLApp.Model;

namespace XMLApp.DTO
{
    public class NewFlightDTO
    {
        public GeoLocation? TakeOffLocation { get; set; }
        public GeoLocation? LandingLocation { get; set; }
        public DateTime? TakeOffDate { get; set; }
        public DateTime? LandingDate { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
