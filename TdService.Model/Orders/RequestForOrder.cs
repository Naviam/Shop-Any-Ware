// -----------------------------------------------------------------------
// <copyright file="RequestForOrder.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Infrastructure.Domain;

    /// <summary>
    /// This class describes user's request for an order.
    /// </summary>
    public class RequestForOrder : EntityBase<int>
    {
        public string ShopName { get; set; }

        public string S { get; set; }

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}