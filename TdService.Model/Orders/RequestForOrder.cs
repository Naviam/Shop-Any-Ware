// -----------------------------------------------------------------------
// <copyright file="RequestForOrder.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System;
    using Infrastructure.Domain;

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

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}