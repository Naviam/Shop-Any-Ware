// -----------------------------------------------------------------------
// <copyright file="IUnitOfWork.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Infrastructure.UnitOfWork
{
    using Domain;

    /// <summary>
    /// The Unit of Work contract is kept outside the repository project because the concrete implementation
    /// is of no concern to the domain services that will use it. It will be trivial to change data layer
    /// implementations at a later date; stub implementations of the Unit of Work pattern can be created for
    /// your unit tests.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Register amended.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="unitofWorkRepository">
        /// The unit of work repository.
        /// </param>
        void RegisterAmended(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);

        /// <summary>
        /// Register new.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="unitofWorkRepository">
        /// The unit of work repository.
        /// </param>
        void RegisterNew(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);

        /// <summary>
        /// Register removed.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="unitofWorkRepository">
        /// The unit of work repository.
        /// </param>
        void RegisterRemoved(IAggregateRoot entity, IUnitOfWorkRepository unitofWorkRepository);

        /// <summary>
        /// Commit changes.
        /// </summary>
        void Commit();
    }
}