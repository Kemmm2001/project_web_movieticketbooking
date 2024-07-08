using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : Controller
    {
        private readonly booking_movie_ticketContext _context;

        public TicketController(booking_movie_ticketContext context)
        {
            _context = context;
        }

        [HttpPost("update-status/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] int status)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            ticket.Status = status;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPost("update-isdeleted/{id}")]
        public async Task<IActionResult> UpdateIsDeleted(int id, [FromBody] bool isDeleted)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            ticket.IsDeleted = isDeleted;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
