using System.ComponentModel.DataAnnotations;

namespace AcmeGames.Models
{
    public class ChangeUserDataRequest
    {
        [Required(ErrorMessage = "First Name required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "First Name must contains at least 1 symbol")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last Name required")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last Name must contains at least 1 symbol")]
        public string LastName { get; set; }
        
        [Required(ErrorMessage = "Email Address required")]
        [EmailAddress]
        public string EmailAddress { get; set; }
        
        [DataType(DataType.Password)]
        [StringLength(20, ErrorMessage = "Password length must be between 3 and 20 symbols")]
        public string Password { get; set; }
        
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and Confirm Password don't match")]
        public string ConfirmPassword { get; set; }
    }
}