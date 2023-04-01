using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using XMLApp.Attributes;

namespace XMLApp.Model
{
    [BsonCollection("flights")]
    public class Flight : Document
    {
        public GeoLocation? TakeOffLocation { get; set; }
        public GeoLocation? LandingLocation { get; set; }
        public DateTime TakeOffDate { get; set; }
        public DateTime LandingDate { get; set; }
        public Ticket? Ticket { get; set; }
        public string TicketId { get; set; }
    }
}
