using System.Text.Json.Serialization;
using XMLApp.NewFolder;

namespace XMLApp.Model
{
    public class TicketFilterDTO
    {
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
