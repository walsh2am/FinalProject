using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly AppDbContext _context;

    public MovieController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovies(int? id)
    {
        if (id == null || id == 0)
        {
            return await _context.Movie
                .Take(5)
                .ToListAsync();
        }

        var movie = await _context.Movie.FindAsync(id.Value);

        if (movie == null)
        {
            return NotFound();
        }

        return Ok(movie);
    }

    [HttpPost]
    public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
    {
        _context.Movie.Add(movie);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetMovies),
            new { id = movie.MovieId },
            movie);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMovie(
        int id,
        Movie movie)
    {
        if (id != movie.MovieId)
        {
            return BadRequest();
        }

        _context.Entry(movie).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        var movie = await _context.Movie.FindAsync(id);

        if (movie == null)
        {
            return NotFound();
        }

        _context.Movie.Remove(movie);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}