using CricketPlayer.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CricketPlayer.Domain.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(1, 15,
        ErrorMessage = "Player Rank must be between 1 and 15.")]
        public int Rank { get; set; }

        [Required]
        public string FirstName { get; set; }

        [MaybeNull]
        public string LastName { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{DD.MM.YYYY}")]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Player Role")]
        public PlayerRole Role { get; set; }

        [Required]
        [Display(Name = "Batting Style")]
        public BattingStyle BattingStyle { get; set; }

        [Required]
        [Display(Name = "Bowling Style")]
        public BowlingStyle BowlingStyle { get; set; }

        public Player(int rank, string firstName, string lastName, DateTime dateOfBirth, PlayerRole role, BattingStyle battingStyle, BowlingStyle bowlingStyle)
        {
            Rank = rank;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Role = role;
            BattingStyle = battingStyle;
            BowlingStyle = bowlingStyle;
        }

        public Player() 
        { 

        }
    }
}
