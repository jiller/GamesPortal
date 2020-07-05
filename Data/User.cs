using System;

namespace AcmeGames.Data
{
	public class User
	{
	    public string	UserAccountId { get; set; }
	    public string	FirstName { get; set; }
	    public string	LastName { get; set; }
	    public DateTime	DateOfBirth { get; set; }
	    public string	EmailAddress { get; set; }
	    public string	Password { get; set; }
	    public bool		IsAdmin { get; set; }
	}
}
