﻿using AcmeGames.Domain.Users.Model;
using MediatR;

namespace AcmeGames.Domain.Users.Requests
{
    public class GetUserByEmailAndPassword: IRequest<UserDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}