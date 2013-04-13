// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddItemImageResponse.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The add item image reponse.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    /// <summary>
    /// The add item image response.
    /// </summary>
    public class AddItemImageResponse : ResponseBase
    {
        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        public int ItemId { get; set; }
    }
}
