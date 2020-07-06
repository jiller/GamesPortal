namespace AcmeGames.Controllers.Admin.Requests
{
    public class SearchUsersRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int PageNumber { get; set; }
        public int Limit { get; set; }
    }
}