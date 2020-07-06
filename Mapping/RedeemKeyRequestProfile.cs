using AcmeGames.Controllers.Requests;
using AcmeGames.Domain.Games.Requests;
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