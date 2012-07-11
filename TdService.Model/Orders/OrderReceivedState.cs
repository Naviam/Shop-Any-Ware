// -----------------------------------------------------------------------
// <copyright file="OrderReceivedState.cs" company="TdService">
// Vitali Hatalski. 2012.
// </copyright>
// -----------------------------------------------------------------------

namespace TdService.Model.Orders
{
    /// <summary>
    /// Describes the received order behavior.
    /// </summary>
    public class OrderReceivedState : IOrderState
    {
        /// <summary>
        /// Flag that says whether items are editable in this order.
        /// </summary>
        public bool CanEditItems
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Flag that says whether this order is editable.
        /// </summary>
        public bool CanEditOrder
        {
            get
            {
                return false;
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
                return true;
            }
        }

        /// <summary>
        /// Flag that says whether this order can be removed.
        /// </summary>
        public bool CanRemoveOrder
        {
            get
            {
                return false;
            }
        }
    }
}