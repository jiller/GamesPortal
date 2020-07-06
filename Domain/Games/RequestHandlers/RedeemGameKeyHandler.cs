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
    public class RedeemGameKeyHandler: AsyncRequestHandler<RedeemGameKey>
    {
        private readonly Database db;

        public RedeemGameKeyHandler(Database db)
        {
            this.db = db;
        }
        
        protected override async Task Handle(RedeemGameKey request, CancellationToken cancellationToken)
        {
            // TODO: Cover this logic with database transaction to prevent some data collision
            
            // Verify that redeem key exists and wasn't use
            var gameKey = await db.GetFirstOrDefaultAsync<GameKey>(k => k.Key.Equals(request.GameKey));
            if (gameKey == null || gameKey.IsRedeemed)
            {
                throw new ApiException("Redeem Key was not found or was already in use.");
            }

            // Verify that user doesn't own the game
            var ownedGame = await db.GetFirstOrDefaultAsync<Ownership>(o => o.GameId == gameKey.GameId && o.State == OwnershipState.Owned);
            if (ownedGame != null)
            {
                throw new ApiException("User already owned that game.");
            }

            // Verify age restriction
            var game = await db.GetFirstOrDefaultAsync<Game>(g => g.GameId == gameKey.GameId);
            var user = await db.GetFirstOrDefaultAsync<User>(u => u.UserAccountId.Equals(request.UserAccountId));
            if (UserTooYongToRedeemGame(user, game))
            {
                throw new ApiException($"User must be older than {game.AgeRestriction ?? 0} years");
            }

            // Grant game ownership to the user
            var ownership = new Ownership
            {
                OwnershipId = 0, // Let database generate OwnershipId
                State = OwnershipState.Owned,
                GameId = game.GameId,
                RegisteredDate = DateTime.UtcNow.ToString("yyyy-MM-dd"),
                UserAccountId = user.UserAccountId
            };

            db.Add(ownership);
            gameKey.IsRedeemed = true;

            // Submit all changes to database
            await db.SubmitAsync();
        }

        private bool UserTooYongToRedeemGame(User user, Game game)
        {
            var gameUnrestricted = game.AgeRestriction == null || game.AgeRestriction.Value == 0;
            if (gameUnrestricted)
            {
                return false;
            }

            var minUserDateOfBirth = DateTime.UtcNow.AddYears(- (int)game.AgeRestriction.Value);
            return minUserDateOfBirth > user.DateOfBirth;
        }
    }
}