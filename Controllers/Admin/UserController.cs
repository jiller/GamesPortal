using System.Collections.Generic;
using System.Threading.Tasks;
using AcmeGames.Controllers.Admin.Requests;
using AcmeGames.Domain.Users.Model;
using AcmeGames.Domain.Users.Requests;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcmeGames.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/admin/user")]
    public class UserController : BaseAdminController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public UserController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        
        [HttpGet]
        [Route("{userAccountId}")]
        public async Task<UserDto> GetByAccountId(string userAccountId)
        {
            return await mediator.Send(new GetUserByAccountId
            {
                UserAccountId = userAccountId
            });
        }

        [HttpPost]
        [Route("search")]
        public async Task<IEnumerable<UserDto>> Search([FromBody] SearchUsersRequest request)
        {
            return await mediator.Send(mapper.Map<SearchUsers>(request));
        }
        
        [HttpPut]
        [Route("{userAccountId}")]
        public async Task<IActionResult> Put([FromQuery] string userAccountId, [FromBody] ChangeUserDataByAdminRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var accountDetails = mapper.Map<UpdateUserAccountDetailsByAdmin>(request);
            accountDetails.UserAccountId = userAccountId;

            await mediator.Send(accountDetails);
            return Ok();
        }
    }
}