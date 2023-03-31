using XMLApp.Attributes;

namespace XMLApp.Model
{
    [BsonCollection("tickets")]
    public class Ticket : Document
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}