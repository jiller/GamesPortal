using AcmeGames.Data;
using AcmeGames.Domain.Games.Model;
using AutoMapper;
using JetBrains.Annotations;

namespace AcmeGames.Domain.Games.Mapping
{
    [UsedImplicitly]
    public class GameProfile: Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameDto>();
        }
    }
}