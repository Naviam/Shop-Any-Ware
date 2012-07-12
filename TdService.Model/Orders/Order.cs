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
    using TdService.Model.Membership;

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
        /// Order status.
        /// </summary>
        private OrderStatus orderStatus;

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order(OrderStatus orderStatus)
        {
            this.orderStatus = orderStatus;
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
        /// Created by user.
        /// </summary>
        public User CreatedByUser { get; set; }

        /// <summary>
        /// Gets or sets Items.
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Gets Created Date.
        /// </summary>
        public DateTime CreatedDate { get; private set; }

        /// <summary>
        /// Gets or sets Received Date.
        /// </summary>
        public DateTime? ReceivedDate { get; private set; }

        /// <summary>
        /// Gets or sets date of order return.
        /// </summary>
        public DateTime? ReturnedDate { get; private set; }

        /// <summary>
        /// Gets or sets date of disposal.
        /// </summary>
        public DateTime? DisposedDate { get; private set; }

        /// <summary>
        /// Gets or sets Weight.
        /// </summary>lf
        public Weight Weight { get; set; }

        /// <summary>
        /// Gets Order Status.
        /// </summary>
        public OrderStatus Status
        {
            get
            {
                return this.orderStatus;
            }
            set
            {
                switch (value)
                {
                    case OrderStatus.New:
                        if (this.orderState == null)
                        {
                            this.orderState = new OrderCreatedState();
                            this.CreatedDate = DateTime.UtcNow;
                        }
                        else
                        {
                            throw new InvalidOperationException("Only new order can be set to created state.");
                        }
                        break;
                    case OrderStatus.Received:
                        if (this.orderState.CanOrderBeReceived)
                        {
                            this.orderState = new OrderReceivedState();
                            this.ReceivedDate = DateTime.UtcNow;
                        }
                        else
                        {
                            throw new InvalidOperationException("This order cannot be set into received state.");
                        }
                        break;
                    case OrderStatus.Returned:
                        if (this)
                        this.orderState = new OrderReturnedState();
                        this.ReturnedDate = DateTime.UtcNow;
                        break;
                    case OrderStatus.Disposed:
                        this.orderState = new OrderDisposedState();
                        this.DisposedDate = DateTime.UtcNow;
                        break;
                }

                this.orderStatus = value;
            }
        }

        /// <summary>
        /// Gets or sets Extended Status.
        /// </summary>
        public OrderExtendedStatus StatusExtended { get; set; }

        /// <summary>
        /// Create new order.
        /// </summary>
        /// <returns></returns>
        public Order CreateNew(Retailer retailer)
        {
            var order = new Order();
            order.Status = OrderStatus.New;
            orderState = new OrderCreatedState();
            return order;
        }

        /// <summary>
        /// Add item to an order.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void AddItem(Item item)
        {
            if (this.orderState.CanEditItems)
            {
                this.Items.Add(item);
            }
            else
            {
                throw new InvalidOperationException("Item cannot be added to order that is not in created state.");
            }
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