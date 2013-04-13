// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRetailerRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IRetailerRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for retailer repository.
    /// </summary>
    public interface IRetailerRepository
    {
        /// <summary>
        /// Get all retailers.
        /// </summary>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; TdService.Model.Common.Retailer].
        /// </returns>
        List<Retailer> GetAll();

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
        /// Save changes to DB.
        /// </summary>
        /// <returns>
        /// DB change result.
        /// </returns>
        int SaveChanges();
    }
}