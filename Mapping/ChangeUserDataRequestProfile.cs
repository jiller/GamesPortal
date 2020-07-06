using AcmeGames.Controllers.Requests;
using AcmeGames.Domain.Users.Model;
using AcmeGames.Domain.Users.Requests;
using AutoMapper;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis.Options;

namespace AcmeGames.Mapping
{
    [UsedImplicitly]
    public class ChangeUserDataRequestProfile: Profile
    {
        public ChangeUserDataRequestProfile()
        {
            CreateMap<ChangeUserDataRequest, UpdateUserAccountDetails>()
                .ForMember(dst => dst.FirstName, opt => opt.MapFrom(x => x.FirstName))
                .ForMember(dst => dst.LastName, opt => opt.MapFrom(x => x.LastName))
                .ForMember(dst => dst.EmailAddress, opt => opt.MapFrom(x => x.EmailAddress))
                .ForMember(dst => dst.NewPassword, opt => opt.MapFrom(x => x.Password))
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}