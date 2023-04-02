using System.Linq.Expressions;
using XMLApp.DTO;
using XMLApp.Model;

namespace XMLApp.Filters
{
    public static class FlightFilterExtension
    {
        public static Expression<Func<Flight, bool>> GetFilterExpression(this FlightFilterDTO filter)
        {
            DateTime filterDate = new DateTime(filter.Date.Year, filter.Date.Month, filter.Date.Day, 0, 0, 0);
            Expression<Func<Flight, bool>> filterExpression = f => f.TakeOffDate.Year == filterDate.Year && f.TakeOffDate.Month == filterDate.Month && f.TakeOffDate.Day == filterDate.Day &&
                                                     f.TakeOffLocation.Country.ToLower().Contains(filter.TakeOffCountry.ToLower()) &&
                                                     f.TakeOffLocation.City.ToLower().Contains(filter.TakeOffCity.ToLower()) &&
                                                     f.LandingLocation.Country.ToLower().Contains(filter.LandingCountry.ToLower()) &&
                                                     f.LandingLocation.City.ToLower().Contains(filter.LandingCity.ToLower());
            return filterExpression;
        }
    }
}
