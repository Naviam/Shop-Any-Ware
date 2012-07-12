// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderCreatedState.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Describes the newly created order behavior.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Orders
{
    /// <summary>
    /// Describes the newly created order behavior.
    /// </summary>
    public class OrderCreatedState : IOrderState
    {
        /// <summary>
        /// Can this order be received (status changed to received).
        /// </summary>
        public bool CanOrderBeReceived
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Flag that says whether items are editable in this order.
        /// </summary>
        public bool CanEditItems
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Flag that says whether this order is editable.
        /// </summary>
        public bool CanEditOrder
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Flag that says whether this order can be returned.
        /// </summary>
        public bool CanRequestOrderReturn
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Flag that says whether this order can be disposed.
        /// </summary>
        public bool CanDisposeOrder
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Flag that says whether this order can be removed.
        /// </summary>
        public bool CanRemoveOrder
        {
            get
            {
                return true;
            }
        }
    }
}