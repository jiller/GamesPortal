using System;
using System.Threading;
using System.Threading.Tasks;
using AcmeGames.Domain.Users.Model;
using AcmeGames.Domain.Users.Requests;
using MediatR;

namespace AcmeGames.Domain.Users.RequestHandlers
{
    public class GetUserByEmailAndPasswordRequestHandler: IRequestHandler<GetUserByEmailAndPasswordRequest, UserDto>
    {
        public GetUserByEmailAndPasswordRequestHandler()
        {
            
        }
        
        public async Task<UserDto> Handle(GetUserByEmailAndPasswordRequest request, CancellationToken cancellationToken)
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