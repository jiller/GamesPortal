using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AcmeGames.Data;
using AcmeGames.Domain.Games.Model;
using AcmeGames.Domain.Games.Requests;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;

namespace AcmeGames.Domain.Games.RequestHandlers
{
    [UsedImplicitly]
    public class GetAllUserGamesHandler: IRequestHandler<GetAllUserGames, IEnumerable<GameDto>>
    {
        private readonly Database db;
        private readonly IMapper mapper;

        public GetAllUserGamesHandler(Database db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        
        public async Task<IEnumerable<GameDto>> Handle(GetAllUserGames request, CancellationToken cancellationToken)
        {
            var ownedGames = await db.GetAsync<Ownership>(o => o.UserAccountId == request.UserAccountId && o.State == OwnershipState.Owned);

            var gameIds = ownedGames.Select(o => o.GameId).ToArray();
            var games = await db.GetAsync<Game>(g => gameIds.Contains(g.GameId));

            return mapper.Map<IEnumerable<GameDto>>(games);
        }
    }
}