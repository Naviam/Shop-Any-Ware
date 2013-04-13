// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddItemImageRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The add item image request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    /// <summary>
    /// The add item image request.
    /// </summary>
    public class AddItemImageRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        public int ItemId { get; set; }

        /// <summary>
        /// Gets or sets the image name.
        /// </summary>
        public string ImageName { get; set; }

        /// <summary>
        /// Gets or sets the image url.
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
