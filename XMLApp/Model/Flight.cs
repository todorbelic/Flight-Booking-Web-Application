using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using XMLApp.Attributes;

namespace XMLApp.Model
{
    [BsonCollection("flights")]
    public class Flight : Document
    {
        private Flight flight;

        public Flight()
        {
        }

        public Flight(Flight flight)
        {
            this.flight = flight;
        }
        public GeoLocation? TakeOffLocation { get; set; }
        public GeoLocation? LandingLocation { get; set; }
        public DateTime TakeOffDate { get; set; }
        public DateTime LandingDate { get; set; }
        public Ticket? Ticket { get; set; }
        public string TicketId { get; set; }
      
    }
}
