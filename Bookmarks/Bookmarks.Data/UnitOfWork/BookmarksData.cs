namespace Bookmarks.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Models;

    using Repositories;

    public class BookmarksData : IBookmarksData
    {
        private readonly DbContext dbContext;
        private readonly IDictionary<Type, object> repositories;

        public BookmarksData(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users => this.GetRepository<User>();

        public IRepository<Bookmark> Bookmarks => this.GetRepository<Bookmark>();

        public IRepository<Category> Categories => this.GetRepository<Category>();

        public IRepository<Comment> Comments => this.GetRepository<Comment>();

        public IRepository<Vote> Votes => this.GetRepository<Vote>();

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (this.repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)this.repositories[typeof(T)];
            }

            var type = typeof(GenericRepository<T>);
            this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.dbContext));

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
