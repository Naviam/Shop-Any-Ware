// -----------------------------------------------------------------------
// <copyright file="RequestForOrder.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.RFO
{
    using System;
    using Infrastructure.Domain;

    using TdService.Model.Common;
    using TdService.Model.Orders;

    /// <summary>
    /// This class describes user's request for an order.
    /// </summary>
    public class RequestForOrder : EntityBase<int>
    {
        /// <summary>
        /// Gets or sets ShopName.
        /// </summary>
        public string ShopName { get; set; }

        /// <summary>
        /// Gets or sets Retailer.
        /// </summary>
        public Retailer Retailer { get; set; }

        /// <summary>
        /// Validate business rules.
        /// </summary>
        /// <exception cref="NotImplementedException">
        /// not yet implemented
        /// </exception>
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}