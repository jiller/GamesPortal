using AcmeGames.Domain.Games.Requests;
using AcmeGames.Models;
using AutoMapper;
using JetBrains.Annotations;

namespace AcmeGames.Mapping
{
    [UsedImplicitly]
    public class RedeemKeyRequestProfile: Profile
    {
        public RedeemKeyRequestProfile()
        {
            CreateMap<RedeemKeyRequest, RedeemGameKey>();
        }
    }
}