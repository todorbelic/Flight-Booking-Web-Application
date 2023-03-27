using Microsoft.AspNetCore.Http;
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

        // GET: api/Donor
        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_ticketService.Get());
        }

        // GET api/Donor/2
        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            var ticket = _ticketService.Get(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }

        // PUT api/Donor/2
        [HttpPut("{id}")]
        public ActionResult Update(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _ticketService.Update(ticket.Id,ticket);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(ticket);
        }

    }
}
