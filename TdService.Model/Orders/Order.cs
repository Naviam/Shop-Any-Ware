// -----------------------------------------------------------------------
// <copyright file="Order.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System;
    using System.Collections.Generic;

    using TdService.Infrastructure.Domain;
    using TdService.Model.Common;
    using TdService.Model.Items;

    /// <summary>
    /// This class describes the order from online shops.
    /// </summary>
    public class Order : EntityBase<int>
    {
        /// <summary>
        /// Indicates state of this order.
        /// </summary>
        private IOrderState orderState;

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="baseState">
        /// The base state.
        /// </param>
        /// <param name="retailer">
        /// The retailer.
        /// </param>
        public Order(IOrderState baseState, Retailer retailer)
        {
            this.orderState = baseState;
            this.Retailer = retailer;
            this.CreatedDate = DateTime.UtcNow;
            this.Items = new List<Item>();
        }

        /// <summary>
        /// Gets or sets Retailer.
        /// </summary>
        public Retailer Retailer { get; set; }

        /// <summary>
        /// Gets or sets OrderNumber.
        /// </summary>
        public string OrderNumber { get; set; }

        /// <summary>
        /// Gets or sets TrackingNumber.
        /// </summary>
        public string TrackingNumber { get; set; }

        /// <summary>
        /// Gets or sets Items.
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Gets Created Date.
        /// </summary>
        public DateTime CreatedDate { get; private set; }

        /// <summary>
        /// Gets or sets ReceivedDate.
        /// </summary>
        public DateTime? ReceivedDate { get; set; }

        /// <summary>
        /// Gets or sets Weight.
        /// </summary>
        public Weight Weight { get; set; }

        /// <summary>
        /// Gets Order Status.
        /// </summary>
        public OrderStatus Status
        {
            get
            {
                return this.orderState.Status;
            }
        }

        /// <summary>
        /// Gets or sets Extended Status.
        /// </summary>
        public string StatusExtended { get; set; }

        /// <summary>
        /// Add item to an order.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void AddItem(Item item)
        {
            this.Items.Add(item);
        }

        /// <summary>
        /// Change state of this order.
        /// </summary>
        /// <param name="newOrderState">
        /// The order state.
        /// </param>
        internal void Change(IOrderState newOrderState)
        {
            this.orderState = newOrderState;
        }

        /// <summary>
        /// Validate the business logic.
        /// </summary>
        protected override void Validate()
        {
            if (this.Retailer == null)
            {
                this.AddBrokenRule(OrderBusinessRules.RetailerRequired);
            }

            if (this.CreatedDate == DateTime.MinValue)
            {
                this.AddBrokenRule(OrderBusinessRules.CreatedDateRequired);
            }

            if (this.orderState is OrderReceivedState && this.ReceivedDate == DateTime.MinValue)
            {
                this.AddBrokenRule(OrderBusinessRules.ReceivedDateRequired);
            }

            if (this.orderState is OrderReceivedState && this.Weight == null)
            {
                this.AddBrokenRule(OrderBusinessRules.WeightRequired);
            }

            if (!string.IsNullOrEmpty(this.OrderNumber) && this.OrderNumber.Length > 64)
            {
                this.AddBrokenRule(OrderBusinessRules.OrderNumberLength);
            }

            if (!string.IsNullOrEmpty(this.TrackingNumber) && this.TrackingNumber.Length > 64)
            {
                this.AddBrokenRule(OrderBusinessRules.TrackingNumberLength);
            }

            if (!string.IsNullOrEmpty(this.StatusExtended) && this.StatusExtended.Length > 64)
            {
                this.AddBrokenRule(OrderBusinessRules.StatusExtendedLength);
            }
        }
    }
}