namespace SportsSystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    using Migrations;

    public class SportsSystemDbContext : IdentityDbContext<User>
    {
        public SportsSystemDbContext()
            : base("SportsSystem", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SportsSystemDbContext, Configuration>());
        }

        public IDbSet<Vote> Votes { get; set; }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<Match> Matches { get; set; }

        public IDbSet<Bet> Bets { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public static SportsSystemDbContext Create()
        {
            return new SportsSystemDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Match>()
                .HasRequired(m => m.HomeTeam)
                .WithMany(t => t.HomeMatches);

            modelBuilder.Entity<Match>()
                .HasRequired(m => m.AwayTeam)
                .WithMany(t => t.AwayMatches);
        }
    }
}