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
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    using TdService.Model.Orders;

    /// <summary>
    /// Retailer repository.
    /// </summary>
    public class RetailerRepository : IRetailerRepository, IDisposable
    {
        /// <summary>
        /// Shop any ware SQL context.
        /// </summary>
        private readonly ShopAnyWareSql context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RetailerRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public RetailerRepository(ShopAnyWareSql context)
        {
            this.context = context;
        }

        /// <summary>
        /// Get all retailers.
        /// </summary>
        /// <returns>
        /// The System.Collections.Generic.List`1[T -&gt; TdService.Model.Common.Retailer].
        /// </returns>
        public List<Retailer> GetAll()
        {
            return this.context.Retailers.ToList();
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
                ?? this.context.Retailers.SingleOrDefault(r => r.Name == retailer.Name)
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
        /// Save changes to DB.
        /// </summary>
        /// <returns>
        /// Number of changes.
        /// </returns>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}