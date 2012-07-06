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
    /// <summary>
    /// Repository base interface.
    /// </summary>
    public interface IRepository
    {
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