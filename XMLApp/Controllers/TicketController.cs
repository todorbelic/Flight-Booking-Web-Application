using Microsoft.AspNetCore.Mvc;
using XMLApp.Model;
using XMLApp.Services;

namespace XMLApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        // GET: TicketController
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }


        [HttpGet]
        public ActionResult<Flight> GetAll()
        {
            return Ok(_ticketService.Get());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var ticket = await _ticketService.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Ticket ticket)
        {
            await _ticketService.Create(ticket);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _ticketService.Update(ticket.Id.ToString(), ticket);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(ticket);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var ticket = _ticketService.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }

            await _ticketService.Delete(id);
            return Ok();
        }

    }
}
