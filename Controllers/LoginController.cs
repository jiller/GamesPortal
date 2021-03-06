﻿using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AcmeGames.Controllers.Requests;
using AcmeGames.Controllers.Responses;
using AcmeGames.Domain.Users.Requests;
using AcmeGames.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NSwag.Annotations;

namespace AcmeGames.Controllers
{
    [Produces("application/json")]
    [Route("api/login")]
    public class LoginController: Controller
    {
        private readonly IMediator mediator;
        private readonly SigningCredentials mySigningCredentials;

        public LoginController(IConfiguration configuration, IMediator mediator)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            this.mediator = mediator;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTKey"]));
            mySigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        }

        [HttpPost]
        [SwaggerResponse(typeof(TokenResponse))]
        public async Task<IActionResult> Authenticate([FromBody] AuthRequest  authRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var user = await mediator.Send(new GetUserByEmailAndPassword
            {
                Email = authRequest.EmailAddress,
                Password = authRequest.Password
            });

            if (user == null)
            {
                return UnprocessableEntity(new ApiError("Invalid email address or password"));
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,    user.UserAccountId),
                new Claim(ClaimTypes.Name,              user.FullName),
                new Claim(ClaimTypes.GivenName,         user.FirstName),
                new Claim(ClaimTypes.Surname,           user.LastName), 
                new Claim(ClaimTypes.DateOfBirth,       user.DateOfBirth.ToString("yyyy-MM-dd")),
                new Claim(ClaimTypes.Email,             user.EmailAddress),
                new Claim(ClaimTypes.Role,              user.Role)
            };

            var token = new JwtSecurityToken(
                "localhost:56653",
                "localhost:56653",
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: mySigningCredentials);

            return Ok(new TokenResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expires = token.ValidTo
            });
        }
    }
}