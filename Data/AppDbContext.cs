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

}