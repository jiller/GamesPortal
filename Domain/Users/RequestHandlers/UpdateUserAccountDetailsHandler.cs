using System;
using System.Threading;
using System.Threading.Tasks;
using AcmeGames.Domain.Users.Model;
using AcmeGames.Domain.Users.Requests;
using JetBrains.Annotations;
using MediatR;

namespace AcmeGames.Domain.Users.RequestHandlers
{
    [UsedImplicitly]
    public class UpdateUserAccountDetailsHandler: IRequestHandler<UpdateUserAccountDetails, UserDto>
    {
        public async Task<UserDto> Handle(UpdateUserAccountDetails request, CancellationToken cancellationToken)
        {
            // TODO: Implement retrieving user from database
            return new UserDto
            {
                UserAccountId = "fake",
                DateOfBirth = DateTime.Now,
                EmailAddress = "foo@bar.baz",
                FirstName = "Hard",
                LastName = "Codedson",
                IsAdmin = false
            };
        }
    }
}