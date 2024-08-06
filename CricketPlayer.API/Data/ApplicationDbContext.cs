using CricketPlayer.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CricketPlayer.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        DbSet<Player> Player { get; set; }
    }
}
