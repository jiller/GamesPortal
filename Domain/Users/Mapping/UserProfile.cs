using AcmeGames.Data;
using AcmeGames.Domain.Users.Model;
using AutoMapper;
using JetBrains.Annotations;

namespace AcmeGames.Domain.Users.Mapping
{
    [UsedImplicitly]
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Role, opt => opt.MapFrom(x => x.IsAdmin ? "Admin" : "User"));
        }
    }
}