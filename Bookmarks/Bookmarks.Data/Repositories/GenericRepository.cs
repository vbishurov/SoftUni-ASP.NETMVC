namespace Bookmarks.Data.Repositories
{
    using System.Data.Entity;

    public class GenericRepository<T> : IRepository<T>
        where T : class
    {
        private readonly DbContext dbContext;
        private readonly IDbSet<T> entitySet;

        public GenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = dbContext.Set<T>();
        }

        public IDbSet<T> EntitySet => this.entitySet;

        public System.Linq.IQueryable<T> All()
        {
            return this.entitySet;
        }

        public T Find(object id)
        {
            return this.entitySet.Find(id);
        }

        public T Add(T entity)
        {
            return this.ChangeState(entity, EntityState.Added);
        }

        public T Update(T entity)
        {
            return this.ChangeState(entity, EntityState.Modified);
        }

        public void Remove(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public T Remove(object id)
        {
            var entity = this.Find(id);
            this.Remove(entity);
            return entity;
        }

        public void SaveChanges()
        {
            this.dbContext.SaveChanges();
        }

        private T ChangeState(T entity, EntityState state)
        {
            var entry = this.dbContext.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.entitySet.Attach(entity);
            }

            entry.State = state;
            return entity;
        }
    }
}
