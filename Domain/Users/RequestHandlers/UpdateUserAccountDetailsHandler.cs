using System.Threading;
using System.Threading.Tasks;
using AcmeGames.Data;
using AcmeGames.Domain.Users.Model;
using AcmeGames.Domain.Users.Requests;
using AcmeGames.Filters;
using AutoMapper;
using JetBrains.Annotations;
using MediatR;

namespace AcmeGames.Domain.Users.RequestHandlers
{
    [UsedImplicitly]
    public class UpdateUserAccountDetailsHandler: IRequestHandler<UpdateUserAccountDetails, UserDto>
    {
        private readonly Database db;
        private readonly IMapper mapper;

        public UpdateUserAccountDetailsHandler(Database db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        
        public async Task<UserDto> Handle(UpdateUserAccountDetails request, CancellationToken cancellationToken)
        {
            var user = await db.GetFirstOrDefaultAsync<User>(u => u.UserAccountId.Equals(request.UserAccountId));
            if (user == null)
            {
                throw new ApiException("User not found");
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.EmailAddress = request.EmailAddress;

            if (!string.IsNullOrEmpty(request.NewPassword))
            {
                user.Password = request.NewPassword;
            }

            await db.SubmitAsync();

            return mapper.Map<UserDto>(user);
        }
    }
}