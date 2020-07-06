using System;

namespace AcmeGames.Domain.Users.Model
{
    public class UserDto
    {
        public string UserAccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public bool IsAdmin { get; set; }
        public string Role { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}