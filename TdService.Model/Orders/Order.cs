// -----------------------------------------------------------------------
// <copyright file="Order.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// <summary>
// This class describes the order from online shops.
// </summary>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TdService.Infrastructure.Domain;
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
        /// The status.
        /// </summary>
        private OrderStatus status;

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        public Order()
        {
            this.Status = OrderStatus.New;
            this.CreatedDate = DateTime.UtcNow;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="orderStatus">
        /// The order Status.
        /// </param>
        public Order(OrderStatus orderStatus)
        {
            this.Status = orderStatus;
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
        /// Gets or sets the user.
        /// </summary>
        public User User { get; set; }

        /// <summary>
        /// Gets or sets Items.
        /// </summary>
        public List<Item> Items { get; set; }

        /// <summary>
        /// Gets or sets Created Date.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets Received Date.
        /// </summary>
        public DateTime? ReceivedDate { get; set; }

        /// <summary>
        /// Gets or sets date of order return.
        /// </summary>
        public DateTime? ReturnedDate { get; set; }

        /// <summary>
        /// Gets or sets date of disposal.
        /// </summary>
        public DateTime? DisposedDate { get; set; }

        /// <summary>
        /// Gets Order Status.
        /// </summary>
        public OrderStatus Status
        {
            get
            {
                return this.status;
            }

            private set
            {
                this.status = value;
                switch (this.Status)
                {
                    case OrderStatus.New:
                        this.orderState = new OrderNewState();
                        break;
                    case OrderStatus.Received:
                        this.orderState = new OrderReceivedState();
                        break;
                    case OrderStatus.ReturnRequested:
                        this.orderState = new OrderReturnRequestedState();
                        break;
                    case OrderStatus.Returned:
                        this.orderState = new OrderReturnedState();
                        break;
                    case OrderStatus.Disposed:
                        this.orderState = new OrderDisposedState();
                        break;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether can be received.
        /// </summary>
        public bool CanBeReceived
        {
            get
            {
                return this.orderState.CanBeReceived;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this order can be modified.
        /// </summary>
        public bool CanBeModified
        {
            get
            {
                return this.orderState.CanBeModified;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this order can be removed.
        /// </summary>
        public bool CanBeRemoved
        {
            get
            {
                return this.orderState.CanBeRemoved;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this order can be requested for return.
        /// </summary>
        public bool CanBeRequestedForReturn
        {
            get
            {
                return this.orderState.CanBeRequestedForReturn;
            }
        }

        /// <summary>
        /// Gets a value indicating whether items can be modified.
        /// </summary>
        public bool CanItemsBeModified
        {
            get
            {
                return this.orderState.CanItemsBeModified;
            }
        }

        /// <summary>
        /// Gets a value indicating whether items can be added to order.
        /// </summary>
        public bool CanItemsBeAdded
        {
            get
            {
                return this.orderState.CanItemsBeAdded;
            }
        }

        /// <summary>
        /// Gets the items not in package.
        /// </summary>
        public List<Item> ItemsNotInPackage
        {
            get
            {
                return this.Items == null ? new List<Item>() : this.Items.Where(i => !i.PackageId.HasValue).ToList();
            }
        }

        /// <summary>
        /// Create new order.
        /// </summary>
        /// <param name="retailer">
        /// The retailer.
        /// </param>
        /// <returns>
        /// The order.
        /// </returns>
        public static Order CreateNew(Retailer retailer)
        {
            var order = new Order(OrderStatus.New) { Retailer = retailer, CreatedDate = DateTime.UtcNow };
            return order;
        }

        /// <summary>
        /// The set as received.
        /// </summary>
        /// <returns>
        /// The <see cref="Order"/>.
        /// </returns>
        public Order SetAsReceived()
        {
            this.Status = OrderStatus.Received;
            this.ReceivedDate = DateTime.UtcNow;
            return this;
        }

        /// <summary>
        /// Add item to an order.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        public void AddItem(Item item)
        {
            if (this.orderState.CanItemsBeModified)
            {
                this.Items.Add(item);
            }
            else
            {
                throw new InvalidOperationException("Item cannot be added to order that is not in created state.");
            }
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="orderNumber">
        /// The order number.
        /// </param>
        /// <param name="trackingNumber">
        /// The tracking number.
        /// </param>
        public void Update(string orderNumber, string trackingNumber)
        {
            if (this.orderState.CanBeModified)
            {
                this.OrderNumber = orderNumber;
                this.TrackingNumber = trackingNumber;
                return;
            }

            throw new InvalidOperationException(ErrorCode.OrderCannotBeUpdated.ToString());
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
            // if (this.Retailer == null)
            // {
            // this.AddBrokenRule(OrderBusinessRules.RetailerRequired);
            // }
            if (this.CreatedDate == DateTime.MinValue)
            {
                this.AddBrokenRule(OrderBusinessRules.CreatedDateRequired);
            }

            if (this.orderState is OrderReceivedState && this.ReceivedDate == DateTime.MinValue)
            {
                this.AddBrokenRule(OrderBusinessRules.ReceivedDateRequired);
            }

            ////if (this.orderState is OrderReceivedState && this.Weight == null)
            ////{
            ////    this.AddBrokenRule(OrderBusinessRules.WeightRequired);
            ////}

            if (!string.IsNullOrEmpty(this.OrderNumber) && this.OrderNumber.Length > 64)
            {
                this.AddBrokenRule(OrderBusinessRules.OrderNumberLength);
            }

            if (!string.IsNullOrEmpty(this.TrackingNumber) && this.TrackingNumber.Length > 64)
            {
                this.AddBrokenRule(OrderBusinessRules.TrackingNumberLength);
            }
        }
    }
}