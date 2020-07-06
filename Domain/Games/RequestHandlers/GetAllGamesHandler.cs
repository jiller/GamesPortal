using System.Collections.Generic;
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
    public class GetAllGamesHandler: IRequestHandler<GetAllGames, IEnumerable<GameDto>>
    {
        private readonly Database db;
        private readonly IMapper mapper;

        public GetAllGamesHandler(Database db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        
        public async Task<IEnumerable<GameDto>> Handle(GetAllGames request, CancellationToken cancellationToken)
        {
            var games = await db.GetAsync<Game>();
            return mapper.Map<IEnumerable<GameDto>>(games);
        }
    }
}