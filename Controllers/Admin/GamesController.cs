using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AcmeGames.Domain.Games.Model;
using AcmeGames.Domain.Games.RequestHandlers;
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
            return await mediator.Send(new GetAllGames());
        }

        [HttpGet]
        [Route("user/{userAccountId}")]
        public async Task<IEnumerable<GameDto>> GetAllUserGames([Required] string userAccountId)
        {
            return await mediator.Send(new GetAllUserGames
            {
                UserAccountId = userAccountId
            });
        }
        
        [HttpPost("user/{userAccountId}/game/{gameId}")]
        public async Task<IActionResult> GrantOwnership([FromQuery, Required] string userAccountId, [FromQuery, Required] uint gameId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            await mediator.Send(new GrantGameOwnershipToUser
            {
                UserAccountId = userAccountId,
                GameId = gameId
            });
            
            return Ok();
        }

        [HttpDelete("user/{userAccountId}/game/{gameId}")]
        public async Task<IActionResult> RevokeOwnership([Required] string userAccountId, [Required] uint gameId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await mediator.Send(new RevokeGameOwnershipFromUser
            {
                UserAccountId = userAccountId,
                GameId = gameId
            });

            return Ok();
        }
    }
}