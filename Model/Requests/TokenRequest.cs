using System.ComponentModel.DataAnnotations;

namespace JwtTokenDemo.Model.Requests
{
    public class TokenRequest {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}