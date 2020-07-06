using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace AcmeGames.Controllers.Admin
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
    public abstract class BaseAdminController : ProtectedController
    {
        protected BaseAdminController()
        {
        }
    }
}