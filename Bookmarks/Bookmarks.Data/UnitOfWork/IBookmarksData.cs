namespace Bookmarks.Data.UnitOfWork
{
    using Models;

    using Repositories;

    public interface IBookmarksData
    {
        IRepository<User> Users { get; }

        IRepository<Bookmark> Bookmarks { get; }

        IRepository<Category> Categories { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Vote> Votes { get; }

        void SaveChanges();
    }
}
