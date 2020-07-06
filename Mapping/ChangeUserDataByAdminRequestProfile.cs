using AcmeGames.Controllers.Admin.Requests;
using AcmeGames.Domain.Users.Requests;
using AutoMapper;
using JetBrains.Annotations;

namespace AcmeGames.Mapping
{
    [UsedImplicitly]
    public class ChangeUserDataByAdminRequestProfile: Profile
    {
        public ChangeUserDataByAdminRequestProfile()
        {
            CreateMap<ChangeUserDataByAdminRequest, UpdateUserAccountDetailsByAdmin>();
        }
    }
}