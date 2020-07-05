using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using AcmeGames.Domain.Users.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcmeGames.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public abstract class ProtectedController : Controller
    {
        private UserDto currentUser;

        protected ProtectedController()
        {
        }

        public UserDto CurrentUser => currentUser ?? (currentUser = ParseUserClaims());
        
        private UserDto ParseUserClaims()
        {
            var claims = User.Claims.ToDictionary(c => c.Type, c => c.Value);

            return new UserDto
            {
                UserAccountId = claims.GetValueOrDefault(ClaimTypes.NameIdentifier),
                FirstName = claims.GetValueOrDefault(ClaimTypes.GivenName),
                LastName = claims.GetValueOrDefault(ClaimTypes.Surname),
                EmailAddress = claims.GetValueOrDefault(ClaimTypes.Email),
                IsAdmin = claims.GetValueOrDefault(ClaimTypes.Role).Equals("Admin"),
                DateOfBirth = DateTime.ParseExact(claims.GetValueOrDefault(ClaimTypes.DateOfBirth), "yyyy-MM-dd", CultureInfo.InvariantCulture)
            };
        }
    }
}