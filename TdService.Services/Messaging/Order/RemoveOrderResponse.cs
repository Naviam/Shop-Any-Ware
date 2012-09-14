// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveOrderResponse.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the RemoveOrderResponse type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Order
{
    /// <summary>
    /// The remove order response.
    /// </summary>
    public class RemoveOrderResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
    }
}