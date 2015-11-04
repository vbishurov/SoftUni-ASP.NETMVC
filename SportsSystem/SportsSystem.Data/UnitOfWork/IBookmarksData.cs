namespace SportsSystem.Data.UnitOfWork
{
    using Repositories;
    using Models;

    public interface IBookmarksData
    {
        IRepository<User> Users { get; }

        IRepository<Team> Teams { get; }

        IRepository<Player> Players { get; }

        IRepository<Match> Matches { get; }

        IRepository<Bet> Bets { get; }

        IRepository<Vote> Votes { get; }

        IRepository<Comment> Comments { get; }

        void SaveChanges();
    }
}
