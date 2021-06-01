using System.ComponentModel.DataAnnotations;

namespace Fysio_API.Models
{
    public class AuthenticateModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
