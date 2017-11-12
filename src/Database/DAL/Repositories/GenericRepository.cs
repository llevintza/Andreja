using System.Collections.Generic;
using System.Linq;

using DAL.Repositories.Interface;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;

namespace DAL.Repositories
{

    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly DbSet<T> dbSet;

        protected GenericRepository(DbSet<T> dbSet)
        {
            this.dbSet = dbSet;
        }

        #region IGenericRepository<T> implementation

        public virtual IQueryable<T> AsQueryable()
        {
            return this.dbSet.AsQueryable();
        }

        public IEnumerable<T> GetAll()
        {
            return this.dbSet;
        }

        public T Add(T entity)
        {
            return this.dbSet.Add(entity);
        }

        public T Delete(T entity)
        {
            return this.dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            this.dbSet.AddOrUpdate(entity);
        }

        #endregion
    }
}
