using MediatR;

namespace AcmeGames.Domain.Games.Requests
{
    public class GrantGameOwnershipToUser : IRequest
    {
        public string UserAccountId { get; set; }
        public uint GameId { get; set; }
    }
}