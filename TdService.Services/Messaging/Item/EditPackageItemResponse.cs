// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EditPackageItemResponse.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The edit package item response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Item
{
    using TdService.Services.Messaging.Item.Base;

    /// <summary>
    /// The edit package item response.
    /// </summary>
    public class EditPackageItemResponse : ItemResponse
    {
        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }
    }
}
