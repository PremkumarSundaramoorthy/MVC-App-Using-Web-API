using CricketPlayer.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CricketPlayer.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

       public DbSet<Player> Player { get; set; }
    }
}
