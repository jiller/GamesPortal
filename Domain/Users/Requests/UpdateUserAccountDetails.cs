using AcmeGames.Domain.Users.Model;
using MediatR;

namespace AcmeGames.Domain.Users.Requests
{
    public class UpdateUserAccountDetails: IRequest<UserDto>
    {
        public string UserAccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string NewPassword { get; set; }
    }
}