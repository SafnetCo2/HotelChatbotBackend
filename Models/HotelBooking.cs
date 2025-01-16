
using System.ComponentModel.DataAnnotations;

namespace HotelChatbotBackend.Models
{
    public class HotelBooking
    {
        public int Id { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        public string RoomType { get; set; } = string.Empty;
    }
}

