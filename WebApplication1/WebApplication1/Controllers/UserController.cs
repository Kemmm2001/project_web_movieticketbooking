using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly booking_movie_ticketContext _context;
        public UserController(booking_movie_ticketContext context)
        {
            _context = context;
        }

        [HttpGet("list-user")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            List<User> User = _context.Users.ToList();
            return User;
        }
        [HttpPost("change-status/{id}")]
        public async Task<IActionResult> ChangeStatus(int id, [FromBody] bool isDeleted)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            user.IsDeleted = isDeleted;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
