using System;
using System.Linq;
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
    public class GetUserByAccountIdHandler: IRequestHandler<GetUserByAccountId, UserDto>
    {
        private readonly Database db;
        private readonly IMapper mapper;

        public GetUserByAccountIdHandler(Database db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        
        public async Task<UserDto> Handle(GetUserByAccountId request, CancellationToken cancellationToken)
        {
            var user = await db.GetFirstOrDefaultAsync<User>(u => u.UserAccountId.Equals(request.UserAccountId));
            return mapper.Map<UserDto>(user);
        }
    }
}