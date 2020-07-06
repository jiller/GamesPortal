using AcmeGames.Controllers.Admin.Requests;
using AcmeGames.Domain.Users.Requests;
using AutoMapper;

namespace AcmeGames.Mapping
{
    public class SearchUsersRequestProfile: Profile
    {
        public SearchUsersRequestProfile()
        {
            CreateMap<SearchUsersRequest, SearchUsers>();
        }
    }
}