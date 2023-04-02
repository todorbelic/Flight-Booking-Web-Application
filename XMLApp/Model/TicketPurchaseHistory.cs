using XMLApp.Attributes;

namespace XMLApp.Model
{
    [BsonCollection("purchaseHistory")]
    public class TicketPurchaseHistory : Document
    {
        public Flight Flight { get; set; }
        public Ticket Ticket { get; set; }
        public User User { get; set; }
        public int NumOfPassengers { get; set; }
        public double TotalPrice { get; set; }
    }
}
