namespace FinalProject.Models;

public class VideoGames
{
    public int VideoGamesId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;

    public int HoursPlayed {get;set;}

    public bool isBestGame { get; set; }
}