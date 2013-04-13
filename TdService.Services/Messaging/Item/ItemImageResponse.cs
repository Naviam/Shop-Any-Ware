// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemImageResponse.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The item image model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    /// <summary>
    /// The item image model.
    /// </summary>
    public class ItemImageResponse
    {
        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }
    }
}
