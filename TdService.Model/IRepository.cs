// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Repository base interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Repository base interface.
    /// </summary>
    /// <typeparam name="T">
    /// Domain entity.
    /// </typeparam>
    public interface IRepository<T> : IDisposable where T : class
    {
        /// <summary>
        /// Get all objects from db.
        /// </summary>
        /// <returns>
        /// Collection of objects.
        /// </returns>
        IQueryable<T> All();
        
        /// <summary>
        /// Get objects from db by filter.
        /// </summary>
        /// <param name="predicate">
        /// Specified a filter.
        /// </param>
        /// <typeparam name="T">
        /// Domain entity.
        /// </typeparam>
        /// <returns>
        /// Collection of objects.
        /// </returns>
        IQueryable<T> Filter<T>(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Find object by keys.
        /// </summary>
        /// <param name="keys">
        /// The keys.
        /// </param>
        /// <returns>
        /// Object from db.
        /// </returns>
        T Find(params object[] keys);

        /// <summary>
        /// Find object by specified expression.
        /// </summary>
        /// <param name="predicate">
        /// The specified expression.
        /// </param>
        /// <returns>
        /// Object from db.
        /// </returns>
        T Find(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Find or add entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="T">
        /// Entity type.
        /// </typeparam>
        /// <returns>
        /// Added or found entity.
        /// </returns>
        T FindOrAdd<T>(T entity);

        /// <summary>
        /// Update entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <typeparam name="T">
        /// Entity type.
        /// </typeparam>
        /// <returns>
        /// Updated entity.
        /// </returns>
        T Update<T>(T entity);

        /// <summary>
        /// Remove entity.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// True if removed.
        /// </returns>
        bool Remove(int id);
    }
}