// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveItemRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The remove item request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    /// <summary>
    /// The remove item request.
    /// </summary>
    public class RemoveItemRequest : RequestBase
    {
       /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }
    }
}
