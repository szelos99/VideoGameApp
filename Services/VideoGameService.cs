// VideoGameService.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VideoGameApp.Data;
using VideoGameApp.Models;

public class VideoGameService
{
    private readonly VideoGameDataContext _context;

    public VideoGameService(VideoGameDataContext context)
    {
        _context = context;
    }

    public async Task<List<VideoGame>> GetGamesAsync()
    {
        return await _context.VideoGames.ToListAsync();
    }

    public async Task<VideoGame> GetGameByIdAsync(int id)
    {
        return await _context.VideoGames.FindAsync(id);
    }

    public async Task<VideoGame> AddGameAsync(VideoGame game)
    {
        _context.VideoGames.Add(game);
        await _context.SaveChangesAsync();
        
        return game;
    }

    public async Task UpdateGameAsync(VideoGame game)
    {
        _context.Entry(game).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteGameAsync(int id)
    {
        var game = await _context.VideoGames.FindAsync(id);
        if (game != null)
        {
            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();
        }

    }
}
