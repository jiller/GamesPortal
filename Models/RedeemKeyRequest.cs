using System.ComponentModel.DataAnnotations;

namespace AcmeGames.Models
{
    public class RedeemKeyRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Game Key must be a string within 3-50 symbols")]
        public string GameKey { get; set; }
    }
}