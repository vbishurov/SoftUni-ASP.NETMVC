namespace SportsSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        private ICollection<Player> players;
        private ICollection<Match> homeMatches;
        private ICollection<Match> awayMatches;
        private ICollection<Vote> votes;

        public Team()
        {
            this.players = new HashSet<Player>();
            this.homeMatches = new HashSet<Match>();
            this.awayMatches = new HashSet<Match>();
            this.votes = new HashSet<Vote>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Nickname { get; set; }

        public string WebSite { get; set; }

        public DateTime? FoundedOn { get; set; }

        public virtual ICollection<Player> Players
        {
            get
            {
                return this.players;
            }

            set
            {
                this.players = value;
            }
        }

        public virtual ICollection<Match> HomeMatches
        {
            get
            {
                return this.homeMatches;
            }

            set
            {
                this.homeMatches = value;
            }
        }

        public virtual ICollection<Match> AwayMatches
        {
            get
            {
                return this.awayMatches;
            }

            set
            {
                this.awayMatches = value;
            }
        }

        public virtual ICollection<Vote> Votes
        {
            get
            {
                return this.votes;
            }

            set
            {
                this.votes = value;
            }
        }
    }
}
