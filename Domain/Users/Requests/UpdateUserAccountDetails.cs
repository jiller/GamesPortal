using AcmeGames.Domain.Users.Model;
using MediatR;

namespace AcmeGames.Domain.Users.Requests
{
    public class UpdateUserAccountDetails: IRequest<UserDto>
    {
        public UserDto User { get; set; }
    }
}