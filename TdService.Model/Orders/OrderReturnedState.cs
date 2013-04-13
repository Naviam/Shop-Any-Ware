// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderReturnedState.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Describe the order behavior when return of an order is in progress.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Orders
{
    /// <summary>
    /// Describe the order behavior when return of an order is in progress.
    /// </summary>
    public class OrderReturnedState : IOrderState
    {
        /// <summary>
        /// Gets a value indicating whether can be received.
        /// </summary>
        public bool CanBeReceived
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can items be modified.
        /// </summary>
        public bool CanItemsBeModified
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can be modified.
        /// </summary>
        public bool CanBeModified
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can be requested for return.
        /// </summary>
        public bool CanBeRequestedForReturn
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can be returned.
        /// </summary>
        public bool CanBeReturned
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can be disposed.
        /// </summary>
        public bool CanBeDisposed
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can be removed.
        /// </summary>
        public bool CanBeRemoved
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can items be added.
        /// </summary>
        public bool CanItemsBeAdded
        {
            get { return false; }
        }
    }
}