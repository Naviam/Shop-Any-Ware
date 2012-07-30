// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderNewState.cs" company="TdService">
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
    public class OrderNewState : IOrderState
    {
        /// <summary>
        /// Gets a value indicating whether order can be received.
        /// </summary>
        public bool CanBeReceived
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether can items be modified.
        /// </summary>
        public bool CanItemsBeModified
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether order can be modified.
        /// </summary>
        public bool CanBeModified
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether order can be requested for return.
        /// </summary>
        public bool CanBeRequestedForReturn
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether order can be returned.
        /// </summary>
        public bool CanBeReturned
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether order can be disposed.
        /// </summary>
        public bool CanBeDisposed
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Gets a value indicating whether order can be removed.
        /// </summary>
        public bool CanBeRemoved
        {
            get
            {
                return true;
            }
        }
    }
}