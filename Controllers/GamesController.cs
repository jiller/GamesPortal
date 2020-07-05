using System.Collections.Generic;
using System.Threading.Tasks;
using AcmeGames.Domain.Games.Model;
using AcmeGames.Domain.Games.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AcmeGames.Controllers
{
	[Produces("application/json")]
	[Route("api/games")]
	public class GamesController : ProtectedController
	{
		private readonly IMediator mediator;

		public GamesController(IMediator mediator)
		{
			this.mediator = mediator;
		}
		
		[HttpGet]
		public async Task<IEnumerable<GameDto>> GetAllGames()
		{
			return await mediator.Send(new GetAllUserGames
			{
				UserAccountId = CurrentUser.UserAccountId
			});
		}
	}
}
