namespace XMLApp.Model
{
    public class Flight
    {
        public int Id { get; set; }
        public GeoLocation? TakeOffLocation { get; set; }
        public GeoLocation? LandingLocation { get; set; }
        public DateTime? TakeOffDate { get; set; }
        public DateTime? LandingDate { get; set; }
        public Ticket? Ticket { get; set; }
    }
}
