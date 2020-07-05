using System;
using AcmeGames.Data;
using AcmeGames.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AcmeGames.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Produces("application/json")]
    [Route("api/user")]
    public class UserController : Controller
    {
        [HttpGet]
        public User Get()
        {
            var user = new User
            {
                UserAccountId = "fake",
                DateOfBirth = DateTime.Now,
                EmailAddress = "foo@bar.baz",
                FirstName = "Hard",
                LastName = "Codedson",
                IsAdmin = false
            };

            return user;
        }

        [HttpPost]
        public User Post(User user)
        {
            var u = new User
            {
                UserAccountId = "fake",
                DateOfBirth = DateTime.Now,
                EmailAddress = "foo@bar.baz",
                FirstName = "Hard",
                LastName = "Codedson",
                IsAdmin = false
            };

            return u;
        }
    }
}