﻿namespace TdService.Model.Orders
{
    /// <summary>
    /// Describe the order behavior when return of an order is in progress.
    /// </summary>
    public class OrderReturnedState : IOrderState
    {
        /// <summary>
        /// Can this order be received (status changed to received).
        /// </summary>
        public bool CanBeReceived
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Flag that says whether items are editable in this order.
        /// </summary>
        public bool CanItemsBeModified
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Flag that says whether this order is editable.
        /// </summary>
        public bool CanBeModified
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Flag that says whether this order can be returned.
        /// </summary>
        public bool CanBeRequestedForReturn
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Flag that says whether this order can be returned.
        /// </summary>
        public bool CanBeReturned
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Flag that says whether this order can be disposed.
        /// </summary>
        public bool CanBeDisposed
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Flag that says whether this order can be removed.
        /// </summary>
        public bool CanBeRemoved
        {
            get
            {
                return false;
            }
        }
    }
}