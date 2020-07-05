using System.Threading.Tasks;
using AcmeGames.Domain.Users.Model;
using AcmeGames.Domain.Users.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcmeGames.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : ProtectedController
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpGet]
        public async Task<UserDto> Get()
        {
            return await mediator.Send(new GetUserByAccountId
            {
                UserAccountId = CurrentUser.UserAccountId
            });
        }

        [HttpPost]
        public async Task<UserDto> Post(UserDto user)
        {
            return await mediator.Send(new UpdateUserAccountDetails
            {
                User = user
            });
        }
    }
}