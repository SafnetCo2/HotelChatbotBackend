using System.ComponentModel.DataAnnotations;
namespace HotelChatbotBackend.Models
{
    
    
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;
    }

}
