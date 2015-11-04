namespace TwitterLike.Data
{
    using TwitterLike.Models;
    using TwitterLike.Repositories;

    public interface ITwitterLikeData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Message> Messages { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<Tweet> Tweets { get; }

        int SaveChanges();
    }
}
