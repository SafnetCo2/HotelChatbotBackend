using Microsoft.AspNetCore.Mvc;
using HotelChatbotBackend.Models;
using HotelChatbotBackend.Data;
using System.Linq;

namespace HotelChatbotBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatbotController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ChatbotController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/chatbot/messages
        [HttpGet("messages")]
        public IActionResult GetMessages()
        {
            var messages = _context.ChatMessages.ToList();
            return Ok(messages);
        }

        // POST: api/chatbot/messages
        [HttpPost("messages")]
        public IActionResult PostMessage([FromBody] ChatMessage message)
        {
            if (message == null)
                return BadRequest();

            _context.ChatMessages.Add(message);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetMessages), new { id = message.Id }, message);
        }

        // GET: api/chatbot/users
        [HttpGet("users")]
        public IActionResult GetUsers()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        // GET: api/chatbot/hotelbookings
        [HttpGet("hotelbookings")]
        public IActionResult GetHotelBookings()
        {
            var hotelBookings = _context.HotelBookings.ToList();
            return Ok(hotelBookings);
        }
    }
}
