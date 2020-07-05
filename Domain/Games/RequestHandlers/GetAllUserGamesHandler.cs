using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AcmeGames.Domain.Games.Model;
using AcmeGames.Domain.Games.Requests;
using JetBrains.Annotations;
using MediatR;

namespace AcmeGames.Domain.Games.RequestHandlers
{
    [UsedImplicitly]
    public class GetAllUserGamesHandler: IRequestHandler<GetAllUserGames, IEnumerable<GameDto>>
    {
        public async Task<IEnumerable<GameDto>> Handle(GetAllUserGames request, CancellationToken cancellationToken)
        {
            // TODO: Implement retrieveing games from database
            return new[]
            {
                new GameDto
                {
                    AgeRestriction = 16,
                    GameId = 1,
                    Name = "Tom Clancy's Rainbow Six® Siege",
                    Thumbnail = "https://ubistatic3-a.akamaihd.net/orbit/uplay_launcher_3_0/assets/ce92dd05207a67d81bb6a3df7bf004c3.jpg"
                }
            };
        }
    }
}