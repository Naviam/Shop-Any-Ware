// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRetailerRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IRetailerRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Common
{
    /// <summary>
    /// Interface for retailer repository.
    /// </summary>
    public interface IRetailerRepository
    {
        /// <summary>
        /// Find or add retailer.
        /// </summary>
        /// <param name="retailer">
        /// The retailer.
        /// </param>
        /// <returns>
        /// Retailer that was found or added.
        /// </returns>
        Retailer FindOrAdd(Retailer retailer);

        /// <summary>
        /// Remove retailer by id.
        /// </summary>
        /// <param name="retailerId">
        /// The retailer id.
        /// </param>
        void Remove(int retailerId);

        /// <summary>
        /// Save changes to db.
        /// </summary>
        /// <returns>
        /// Db change result.
        /// </returns>
        int SaveChanges();
    }
}