// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemovePackageRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   The remove package request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Package
{
    /// <summary>
    /// The remove package request.
    /// </summary>
    public class RemovePackageRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int Id { get; set; }
    }
}