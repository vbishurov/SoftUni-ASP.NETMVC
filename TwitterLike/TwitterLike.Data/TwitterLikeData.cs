namespace TwitterLike.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Models;

    using Repositories;

    public class TwitterLikeData : ITwitterLikeData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        public TwitterLikeData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users => this.GetRepository<ApplicationUser>();

        public IRepository<Message> Messages => this.GetRepository<Message>();

        public IRepository<Notification> Notifications => this.GetRepository<Notification>();

        public IRepository<Tweet> Tweets => this.GetRepository<Tweet>();

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (this.repositories.ContainsKey(type))
            {
                return (IRepository<T>)this.repositories[type];
            }

            var typeOfRepository = typeof(GenericRepository<T>);
            var repository = Activator.CreateInstance(
                typeOfRepository, this.context);

            this.repositories.Add(type, repository);

            return (IRepository<T>)this.repositories[type];
        }
    }
}
