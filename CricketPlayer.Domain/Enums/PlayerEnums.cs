namespace CricketPlayer.Domain.Enums
{
    public enum PlayerRole
    {
        Batter = 0,

        Bowler = 1,

        WicketKeeper = 2,

        BattingAllRounder = 3,

        BowlingAllRounder = 4
    }

    public enum BowlingStyle
    {
        None = 0,

        RightArmFast = 1,

        LeftArmFast = 2,

        OffBreak = 3,

        LegBreak = 4
    }

    public enum BattingStyle
    {
        RightHanded,

        LeftHanded
    }
}