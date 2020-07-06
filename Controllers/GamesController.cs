using System.Collections.Generic;
using System.Threading.Tasks;
using AcmeGames.Domain.Games.Model;
using AcmeGames.Domain.Games.Requests;
using AcmeGames.Models;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcmeGames.Controllers
{
	[Produces("application/json")]
	[Route("api/games")]
	public class GamesController : ProtectedController
	{
		private readonly IMediator mediator;
		private readonly IMapper mapper;

		public GamesController(IMediator mediator, IMapper mapper)
		{
			this.mediator = mediator;
			this.mapper = mapper;
		}
		
		[HttpGet]
		public async Task<IEnumerable<GameDto>> GetAllGames()
		{
			return await mediator.Send(new GetAllUserGames
			{
				UserAccountId = CurrentUser.UserAccountId
			});
		}

		[HttpPost]
		public async Task<IActionResult> RedeemKey([FromBody] RedeemKeyRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await mediator.Send(mapper.Map<RedeemGameKey>(request));
			return Ok();
		}
	}
}
