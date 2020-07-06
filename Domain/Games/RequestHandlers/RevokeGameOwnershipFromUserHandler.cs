using System.Threading;
using System.Threading.Tasks;
using AcmeGames.Data;
using JetBrains.Annotations;
using MediatR;

namespace AcmeGames.Domain.Games.RequestHandlers
{
    [UsedImplicitly]
    public class RevokeGameOwnershipFromUserHandler: AsyncRequestHandler<RevokeGameOwnershipFromUser>
    {
        private readonly Database db;

        public RevokeGameOwnershipFromUserHandler(Database db)
        {
            this.db = db;
        }
        
        protected override async Task Handle(RevokeGameOwnershipFromUser request, CancellationToken cancellationToken)
        {
            var ownership = await db.GetFirstOrDefaultAsync<Ownership>(
                o => o.UserAccountId.Equals(request.UserAccountId) &&
                     o.GameId.Equals(request.GameId));

            if (ownership == null || ownership.State == OwnershipState.Revoked)
            {
                // Ownership already revoked or doesn't exist
                return;
            }

            ownership.State = OwnershipState.Revoked;
            await db.SubmitAsync();
        }
    }
}