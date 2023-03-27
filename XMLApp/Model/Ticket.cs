namespace XMLApp.Model
{
    public class Ticket
    {
        public int Id { get; set; }
        public Flight? Flight { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}