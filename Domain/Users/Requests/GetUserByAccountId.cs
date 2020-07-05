using AcmeGames.Domain.Users.Model;
using MediatR;

namespace AcmeGames.Domain.Users.Requests
{
    public class GetUserByAccountId: IRequest<UserDto>
    {
        public string UserAccountId { get; set; }
    }
}