// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveOrderRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The remove order request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Order
{
    /// <summary>
    /// The remove order request.
    /// </summary>
    public class RemoveOrderRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the Order ID.
        /// </summary>
        public int Id { get; set; }
    }
}