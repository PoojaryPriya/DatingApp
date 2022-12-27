using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDataTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string password { get; set; }
    }
}