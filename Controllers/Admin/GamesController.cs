using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AcmeGames.Domain.Games.Model;
using AcmeGames.Domain.Games.Requests;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcmeGames.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/admin/games")]
    public class GamesController: BaseAdminController
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public GamesController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<GameDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Route("user/{userAccountId}")]
        public async Task<IEnumerable<GameDto>> GetAllUserGames(string userAccountId)
        {
            throw new NotImplementedException();
        }
        
        [HttpPost("user/{userAccountId}/key/{gameKey}")]
        public async Task<IActionResult> RedeemKey([FromQuery] string userAccountId, [FromQuery] string gameKey)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await mediator.Send(new RedeemGameKey
            {
                GameKey = gameKey,
                UserAccountId = userAccountId
            });
            return Ok();
        }

        [HttpPost("user/{userAccountId}/game/{gameId}")]
        public async Task<IActionResult> Delete(string userAccountId, uint gameId)
        {
            throw new NotImplementedException();
        }
    }
}