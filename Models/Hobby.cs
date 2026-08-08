namespace FinalProject.Models;

public class Hobby
{
    public int HobbyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;

    public string SkillLevel {get;set;} = string.Empty;

    public int HoursPerWeek { get; set; }
}