namespace AcmeGames.Domain.Games.Model
{
	public class GameDto
	{
		public uint?	AgeRestriction { get; set; }
		public uint		GameId { get; set; }
		public string	Name { get; set; }
		public string	Thumbnail { get; set; }
	}
}
