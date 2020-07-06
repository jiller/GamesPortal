using System.ComponentModel.DataAnnotations;

namespace AcmeGames.Controllers.Requests
{
    public class AuthRequest
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}