using System.Threading.Tasks;
using AcmeGames.Domain.Users.Model;
using AcmeGames.Domain.Users.Requests;
using AcmeGames.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace AcmeGames.Controllers
{
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : ProtectedController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        
        [HttpGet]
        public async Task<UserDto> Get()
        {
            return await mediator.Send(new GetUserByAccountId
            {
                UserAccountId = CurrentUser.UserAccountId
            });
        }

        [HttpPut]
        [SwaggerResponse(typeof(UserDto))]
        public async Task<IActionResult> Post([FromBody] ChangeUserDataRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userAccountDetails = mapper.Map<UpdateUserAccountDetails>(request);
            userAccountDetails.UserAccountId = CurrentUser.UserAccountId;
            
            var updatedUser= await mediator.Send(userAccountDetails);

            return Ok(updatedUser);
        }
    }
}