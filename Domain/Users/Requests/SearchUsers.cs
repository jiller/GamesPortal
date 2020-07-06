using System.Collections.Generic;
using AcmeGames.Domain.Users.Model;
using MediatR;

namespace AcmeGames.Domain.Users.Requests
{
    public class SearchUsers: IRequest<IEnumerable<UserDto>>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int PageNumber { get; set; }
        public int Limit { get; set; }
    }
}