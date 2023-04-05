using System.Text.Json.Serialization;
using XMLApp.NewFolder;

namespace XMLApp.DTO
{
    public class FlightFilterDTO
    {
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        public DateOnly Date { get; set; }
        public string TakeOffCity { get; set; }
        public string LandingCity { get; set; }
        public int PassengersCount { get; set; }
    }
}
