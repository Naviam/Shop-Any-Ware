// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeRetailerRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The fake retailer repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.ShopAnyWare.Tests.Orders
{
    using TdService.Model.Common;

    /// <summary>
    /// The fake retailer repository.
    /// </summary>
    public class FakeRetailerRepository : IRetailerRepository
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
        public Retailer FindOrAdd(Retailer retailer)
        {
            retailer.Id = 1;
            return retailer;
        }

        /// <summary>
        /// Remove retailer by id.
        /// </summary>
        /// <param name="retailerId">
        /// The retailer id.
        /// </param>
        public void Remove(int retailerId)
        {
        }

        /// <summary>
        /// Save changes to db.
        /// </summary>
        /// <returns>
        /// Db change result.
        /// </returns>
        public int SaveChanges()
        {
            return 0;
        }
    }
}