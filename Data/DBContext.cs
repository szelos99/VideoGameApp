using Microsoft.EntityFrameworkCore;
using VideoGameApp.Models;

namespace VideoGameApp.Data
{
    public class VideoGameDataContext : DbContext
    {
        public string DbPath { get; }
        public DbSet<VideoGame> VideoGames { get; set; }

        public VideoGameDataContext()
        {
            DbPath = "database.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");
    }
}
