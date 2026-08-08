namespace FinalProject.Models;

public class Movie
{
    public int MovieId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;

    public int ReleaseYear {get;set;}

    public double Rating { get; set; }
}