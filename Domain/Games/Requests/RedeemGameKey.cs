using MediatR;

namespace AcmeGames.Domain.Games.Requests
{
    public class RedeemGameKey : IRequest
    {
        public string GameKey { get; set; }
        public string UserAccountId { get; set; }
    }
}