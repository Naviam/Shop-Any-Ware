// -----------------------------------------------------------------------
// <copyright file="IReadOnlyRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Domain
{
    using System.Collections.Generic;
    using Querying;

    /// <summary>
    /// Interface for the group of entities that can be only retrieved.
    /// </summary>
    /// <typeparam name="T">
    /// Any type.
    /// </typeparam>
    /// <typeparam name="TId">
    /// Id of any data type.
    /// </typeparam>
    public interface IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        /// <summary>
        /// Find by Id.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// Found type.
        /// </returns>
        T FindBy(TId id);

        /// <summary>
        /// Get all objects.
        /// </summary>
        /// <returns>
        /// Collection of objects.
        /// </returns>
        IEnumerable<T> FindAll();

        /// <summary>
        /// Find collection of objects by query.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <returns>
        /// Collection of objects.
        /// </returns>
        IEnumerable<T> FindBy(Query query);

        /// <summary>
        /// Find collection of objects by query.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="index">
        /// The index.
        /// </param>
        /// <param name="count">
        /// The count.
        /// </param>
        /// <returns>
        /// Collection of objects.
        /// </returns>
        IEnumerable<T> FindBy(Query query, int index, int count);
    }
}