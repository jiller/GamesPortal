using MediatR;

namespace AcmeGames.Domain.Games.RequestHandlers
{
    public class RevokeGameOwnershipFromUser: IRequest
    {
        public string UserAccountId { get; set; }
        public uint GameId { get; set; }
    }
}