using System;
using MediatR;

namespace AcmeGames.Domain.Users.Requests
{
    public class UpdateUserAccountDetailsByAdmin: IRequest
    {
        public string UserAccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string NewPassword { get; set; }
        public DateTime	DateOfBirth { get; set; }
        public bool IsAdmin { get; set; } 
    }
}