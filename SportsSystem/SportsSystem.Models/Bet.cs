namespace SportsSystem.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Bet
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("Match")]
        public int MatchId { get; set; }

        public virtual Match Match { get; set; }

        public decimal HomeTeamBet { get; set; }

        public decimal AwayTeamBet { get; set; }
    }
}
