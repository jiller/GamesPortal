using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AcmeGames.Data;
using AcmeGames.Domain.Users.Model;
using AcmeGames.Domain.Users.Requests;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;

namespace AcmeGames.Domain.Users.RequestHandlers
{
    [UsedImplicitly]
    public class SearchUsersHandler: IRequestHandler<SearchUsers, IEnumerable<UserDto>>
    {
        private readonly Database db;
        private readonly IMapper mapper;

        public SearchUsersHandler(Database db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        
        public async Task<IEnumerable<UserDto>> Handle(SearchUsers request, CancellationToken cancellationToken)
        {
            var users = await db.GetAsync<User>(u => FilterUser(u, request), request.PageNumber, request.Limit);
            return mapper.Map<IEnumerable<UserDto>>(users);
        }

        private bool FilterUser(User user, SearchUsers filter)
        {
            return FieldMatched(user.FirstName, filter.FirstName) &&
                   FieldMatched(user.LastName, filter.LastName) &&
                   FieldMatched(user.EmailAddress, filter.EmailAddress);
        }

        private bool FieldMatched(string fieldValue, string searchText)
        {
            return string.IsNullOrWhiteSpace(searchText) || fieldValue.Contains(searchText);
        }
    }
}