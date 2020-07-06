using System;
using AcmeGames.Controllers.Requests;

namespace AcmeGames.Controllers.Admin.Requests
{
    public class ChangeUserDataByAdminRequest : ChangeUserDataRequest
    {
        public DateTime	DateOfBirth { get; set; }
        public bool IsAdmin { get; set; } 
    }
}