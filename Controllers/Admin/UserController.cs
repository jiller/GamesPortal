using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcmeGames.Controllers.Requests;
using AcmeGames.Domain.Users.Model;
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
        public async Task<IEnumerable<UserDto>> Get()
        {
            throw new NotImplementedException();
        }
        
        [HttpGet]
        [Route("{userAccountId}")]
        public async Task<IEnumerable<UserDto>> GetByAccountId(string userAccountId)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("search")]
        public async Task<IEnumerable<UserDto>> Search()
        {
            throw new NotImplementedException();
        }
        
        [HttpPut]
        [Route("{userAccountId}")]
        public async Task<IActionResult> Put([FromQuery] string userAccountId, [FromBody] ChangeUserDataRequest request)
        {
            throw new NotImplementedException();
        }
    }
}