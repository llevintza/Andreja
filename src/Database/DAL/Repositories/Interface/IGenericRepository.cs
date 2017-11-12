using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Interface
{
    /// <summary>
    /// The GenericRepository interface.
    /// </summary>
    /// <typeparam name="T">Type of the elements in reposotory.</typeparam>
    public interface IGenericRepository<T>
    {
        /// <summary>
        /// The as queryable.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        IQueryable<T> AsQueryable();

        /// <summary>
        /// The get all.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T Add(T entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T Delete(T entity);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Update(T entity);
    }
}
