using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProject.Data;
using FinalProject.Models;

namespace FinalProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VideoGamesController : ControllerBase
{
    private readonly AppDbContext _context;

    public VideoGamesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<VideoGames>>> GetVideoGames(int? id)
    {
        if (id == null || id == 0)
        {
            return await _context.VideoGames
                .Take(5)
                .ToListAsync();
        }

        var videoGame = await _context.VideoGames.FindAsync(id.Value);

        if (videoGame == null)
        {
            return NotFound();
        }

        return Ok(videoGame);
    }

    [HttpPost]
    public async Task<ActionResult<VideoGames>> CreateVideoGame(VideoGames videoGame)
    {
        _context.VideoGames.Add(videoGame);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetVideoGames),
            new { id = videoGame.VideoGamesId },
            videoGame);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVideoGame(
        int id,
        VideoGames videoGame)
    {
        if (id != videoGame.VideoGamesId)
        {
            return BadRequest();
        }

        _context.Entry(videoGame).State = EntityState.Modified;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVideoGame(int id)
    {
        var videoGame = await _context.VideoGames.FindAsync(id);

        if (videoGame == null)
        {
            return NotFound();
        }

        _context.VideoGames.Remove(videoGame);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}