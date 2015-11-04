namespace SportsSystem.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Vote
    {
        public int Id { get; set; }

        public int PlusCount { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }
    }
}
