using System.ComponentModel.DataAnnotations;
namespace HotelChatbotBackend.Models
{

    public class ChatMessage
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Message { get; set; } = string.Empty;
    }

}
