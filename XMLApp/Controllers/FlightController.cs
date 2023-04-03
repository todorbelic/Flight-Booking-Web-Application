using Microsoft.AspNetCore.Mvc;
using XMLApp.DTO;
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

        [HttpGet("test")]
        public ActionResult<Flight> Test()
        {
            Flight flight = new Flight() { TicketId="12" };
            return Ok(flight) ;
        }

        [HttpGet("available")]
        public ActionResult<FlightFilterResultDTO> GetAvailable()
        {
            return Ok(_flightService.GetAvailable());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var flight = await _flightService.GetById(id);
            if(flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }

        [HttpPost("getFiltered")]
        public ActionResult GetFiltered([FromBody] FlightFilterDTO filterDTO)
        {
            var flights = _flightService.GetByFilter(filterDTO);
            return Ok(flights);
        }

        // POST api/<FlightController>
        [HttpPost]
        public async Task<ActionResult> Post(NewFlightDTO flight)
        {
            await _flightService.Create(flight);
            return Ok();
        }

        // PUT api/<FlightController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Flight flight)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _flightService.Update(flight.Id.ToString(), flight);
            } catch
            {
                return BadRequest();
            }

            return Ok(flight);
        }

        // DELETE api/<FlightController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var flight = _flightService.GetById(id);
            if(flight == null)
            {
                return NotFound();
            }

            await _flightService.Delete(id);
            return Ok();
        }
    }
}
