using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XMLApp.Model;
using XMLApp.Services;


namespace XMLApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        
        [HttpGet]
        public ActionResult<Flight> GetAll()
        {
            return Ok(_flightService.Get());
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var flight = _flightService.GetById(id);
            if(flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }

        // POST api/<FlightController>
        [HttpPost]
        public ActionResult Post(Flight flight)
        {
            return Ok(_flightService.Create(flight));
        }

        // PUT api/<FlightController>/5
        [HttpPut("{id}")]
        public ActionResult Put(Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _flightService.Update(flight.Id, flight);
            } catch
            {
                return BadRequest();
            }

            return Ok(flight);
        }

        // DELETE api/<FlightController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var flight = _flightService.GetById(id);
            if(flight == null)
            {
                return NotFound();
            }

            _flightService.Delete(id);
            return Ok();
        }
    }
}
