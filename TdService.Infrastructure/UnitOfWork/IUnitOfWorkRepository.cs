// -----------------------------------------------------------------------
// <copyright file="IUnitOfWorkRepository.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.UnitOfWork
{
    using Domain;

    /// <summary>
    /// Each repository within the solution is required to implement the IUnitOfWorkRepository.
    /// </summary>
    public interface IUnitOfWorkRepository
    {
        /// <summary>
        /// Persist creation of an entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void PersistCreationOf(IAggregateRoot entity);

        /// <summary>
        /// Persist update of an entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void PersistUpdateOf(IAggregateRoot entity);

        /// <summary>
        /// Persist removal of an entity.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void PersistDeletionOf(IAggregateRoot entity);
    }
}
