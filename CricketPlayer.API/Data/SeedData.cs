using CricketPlayer.API.Enums;
using CricketPlayer.API.Models;

namespace CricketPlayer.API.Data
{
    public class SeedData
    {
        public static async Task SeedDataAsync(ApplicationDbContext _dbContext)
        {
            if (!_dbContext.Player.Any())
            {
                _dbContext.Player.AddRange(
                    new Player(1, "Virat", "Kohli", new DateTime(1988, 05, 11), PlayerRole.Batter,
                    BattingStyle.RightHanded, BowlingStyle.RightArmFast),

                    new Player(3, "Rohit", "Sharma", new DateTime(1987, 04, 30), PlayerRole.Batter,
                    BattingStyle.RightHanded, BowlingStyle.OffBreak),

                    new Player(2, "Jasprit", "Bumrah", new DateTime(1993, 06, 12), PlayerRole.Bowler,
                    BattingStyle.RightHanded, BowlingStyle.RightArmFast),

                    new Player(6, "Ravindra", "Jadeja", new DateTime(1988, 06, 12), PlayerRole.BowlingAllRounder,
                    BattingStyle.LeftHanded, BowlingStyle.LegBreak),

                    new Player(8, "Ravichandran", "Ashwin", new DateTime(1986, 09, 17), PlayerRole.BowlingAllRounder,
                    BattingStyle.RightHanded, BowlingStyle.OffBreak),

                    new Player(4, "Hardik", "Pandy", new DateTime(1993, 10, 11), PlayerRole.BattingAllRounder,
                    BattingStyle.RightHanded, BowlingStyle.RightArmFast),

                    new Player(7, "Mohammad", "Shami", new DateTime(1990, 03, 09), PlayerRole.Bowler,
                    BattingStyle.RightHanded, BowlingStyle.RightArmFast),

                    new Player(5, "Kl Rahul", "", new DateTime(1992, 04, 18), PlayerRole.WicketKeeper,
                    BattingStyle.RightHanded, BowlingStyle.None));

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
