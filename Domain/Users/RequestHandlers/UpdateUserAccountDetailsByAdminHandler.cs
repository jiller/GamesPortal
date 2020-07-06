using System.Threading;
using System.Threading.Tasks;
using AcmeGames.Data;
using AcmeGames.Domain.Users.Requests;
using AcmeGames.Filters;
using JetBrains.Annotations;
using MediatR;

namespace AcmeGames.Domain.Users.RequestHandlers
{
    [UsedImplicitly]
    public class UpdateUserAccountDetailsByAdminHandler: AsyncRequestHandler<UpdateUserAccountDetailsByAdmin>
    {
        private readonly Database db;

        public UpdateUserAccountDetailsByAdminHandler(Database db)
        {
            this.db = db;
        }

        protected override async Task Handle(UpdateUserAccountDetailsByAdmin request, CancellationToken cancellationToken)
        {
            var user = await db.GetFirstOrDefaultAsync<User>(u => u.UserAccountId.Equals(request.UserAccountId));
            if (user == null)
            {
                throw new ApiException("User not found");
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.EmailAddress = request.EmailAddress;
            user.DateOfBirth = request.DateOfBirth;
            user.IsAdmin = request.IsAdmin;

            if (!string.IsNullOrEmpty(request.NewPassword))
            {
                user.Password = request.NewPassword;
            }

            await db.SubmitAsync();
        }
    }
}