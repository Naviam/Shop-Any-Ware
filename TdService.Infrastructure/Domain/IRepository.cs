// -----------------------------------------------------------------------
// <copyright file="IRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.Domain
{
    /// <summary>
    /// Interface for the group of entities that can be retrieved and persisted.
    /// </summary>
    /// <typeparam name="T">
    /// Any type of object.
    /// </typeparam>
    /// <typeparam name="TId">
    /// Any type of id.
    /// </typeparam>
    public interface IRepository<T, TId> : IReadOnlyRepository<T, TId> where T : IAggregateRoot
    {
        /// <summary>
        /// Save collection of entities.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Save(T entity);

        /// <summary>
        /// Add entity to collection.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Add(T entity);

        /// <summary>
        /// Remove entity from collection.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Remove(T entity);
    }
}