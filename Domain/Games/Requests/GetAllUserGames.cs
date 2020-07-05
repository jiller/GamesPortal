using System.Collections.Generic;
using AcmeGames.Data;
using AcmeGames.Domain.Games.Model;
using MediatR;

namespace AcmeGames.Domain.Games.Requests
{
    public class GetAllUserGames : IRequest<IEnumerable<GameDto>>
    {
        public string UserAccountId { get; set; }
    }
}