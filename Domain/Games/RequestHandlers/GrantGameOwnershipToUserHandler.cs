using System;
using System.Threading;
using System.Threading.Tasks;
using AcmeGames.Data;
using AcmeGames.Domain.Games.Requests;
using AcmeGames.Filters;
using JetBrains.Annotations;
using MediatR;

namespace AcmeGames.Domain.Games.RequestHandlers
{
    [UsedImplicitly]
    public class GrantGameOwnershipToUserHandler: AsyncRequestHandler<GrantGameOwnershipToUser>
    {
        private readonly Database db;

        public GrantGameOwnershipToUserHandler(Database db)
        {
            this.db = db;
        }
        
        protected override async Task Handle(GrantGameOwnershipToUser request, CancellationToken cancellationToken)
        {
            // Verify that user doesn't own the game
            var ownedGame = await db.GetFirstOrDefaultAsync<Ownership>(o => o.GameId == request.GameId && o.State == OwnershipState.Owned);
            if (ownedGame != null)
            {
                throw new ApiException("User already owned that game.");
            }

            // Grant game ownership to the user
            var ownership = new Ownership
            {
                OwnershipId = 0, // Let database generate OwnershipId
                State = OwnershipState.Owned,
                GameId = request.GameId,
                RegisteredDate = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                UserAccountId = request.UserAccountId
            };

            db.Add(ownership);

            // Submit changes to database
            await db.SubmitAsync();
        }
    }
}