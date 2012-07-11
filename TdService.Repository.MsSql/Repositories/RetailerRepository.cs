// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RetailerRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the RetailerRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Repository.MsSql.Repositories
{
    using System;
    using System.Data;
    using System.Linq;

    using TdService.Model.Common;

    /// <summary>
    /// Retailer repository.
    /// </summary>
    public class RetailerRepository : IRetailerRepository
    {
        /// <summary>
        /// Shop any ware sql context.
        /// </summary>
        private readonly ShopAnyWareSql context;

        public RetailerRepository(ShopAnyWareSql context)
        {
            this.context = context;
        }

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
            return this.context.Retailers.SingleOrDefault(r => r.Url == retailer.Url) 
                ?? this.context.Retailers.SingleOrDefault(r => string.Compare(r.Name, retailer.Name, StringComparison.OrdinalIgnoreCase) == 0)
                ?? this.context.Retailers.Add(retailer);
        }

        /// <summary>
        /// Remove retailer by id.
        /// </summary>
        /// <param name="retailerId">
        /// The retailer id.
        /// </param>
        public void Remove(int retailerId)
        {
            var retailer = new Retailer { Id = retailerId };
            this.context.Entry(retailer).State = EntityState.Deleted;
        }

        /// <summary>
        /// Save changes to db.
        /// </summary>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}