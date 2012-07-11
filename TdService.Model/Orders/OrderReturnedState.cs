namespace TdService.Model.Orders
{
    /// <summary>
    /// Describe the order behavior when return of an order is in progress.
    /// </summary>
    public class OrderReturnedState : IOrderState
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
                return false;
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
                return false;
            }
        }
    }
}