namespace TwitterLike.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public virtual DbSet<Tweet> Tweets { get; set; }

        public virtual DbSet<Message> Messages { get; set; }

        //public virtual DbSet<Notification> Notifications { get; set; }

        public ApplicationDbContext()
            : base("TwitterLike", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasRequired(m=>m.FromUser)
                .WithMany(u => u.SentMessages)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.ToUser)
                .WithMany(u => u.ReceivedMessages)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.FavouriteTweets)
                .WithMany(t => t.FavouritedBy)
                .Map(m =>
                {
                    m.ToTable("UsersTweets");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("TweetId");
                });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Retweets)
                .WithMany(t => t.RetweetedBy)
                .Map(m =>
                {
                    m.ToTable("UsersRetweets");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("TweetId");
                });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.ReportedTweets)
                .WithMany(t => t.ReportedBy)
                .Map(m =>
                {
                    m.ToTable("UsersReportedTweets");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("TweetId");
                });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followers)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("UsersFollowers");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FollowerId");
                });

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Following)
                .WithMany()
                .Map(m =>
                {
                    m.ToTable("UsersFollowing");
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FollowedUserId");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}