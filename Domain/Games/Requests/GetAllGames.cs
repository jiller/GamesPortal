using System.Collections.Generic;
using AcmeGames.Domain.Games.Model;
using MediatR;

namespace AcmeGames.Domain.Games.Requests
{
    public class GetAllGames: IRequest<IEnumerable<GameDto>>
    {
    }
}