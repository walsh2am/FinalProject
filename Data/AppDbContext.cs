using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using FinalProject.Data;

namespace FinalProject.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<TeamMember> TeamMembers { get; set; }

    public DbSet<Hobby> Hobby { get; set; }
    
    public DbSet<VideoGames> VideoGames { get; set; }

    public DbSet<Movie> Movie { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<TeamMember>().HasData(
            new TeamMember
            {
                TeamMemberId = 2,
                FullName = "Andrew Walsh",
                Birthdate = new DateTime(2001, 5, 9),
                CollegeProgram = "Software Application Development",
                YearInProgram = "Freshman"
            }
        );

        modelBuilder.Entity<Hobby>().HasData(
            new Hobby
            {
                HobbyId = 6,
                Name = "Guitar",
                Category = "Entertainment",
                SkillLevel = "Intermediate",
                HoursPerWeek = 4
            }
        );

        modelBuilder.Entity<VideoGames>().HasData(
            new VideoGames
            {
                VideoGamesId = 7,
                Name = "Minecraft",
                Genre = "Sandbox",
                HoursPlayed = 200,
                isBestGame = false
            }
        );

        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                MovieId = 6,
                Title = "Star Wars Episode IV",
                Genre = "Sci-fi",
                ReleaseYear = 1977,
                Rating = 5
            }
        );
    }


}