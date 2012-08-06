// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddPackageRequest.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Add package request message.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Package
{
    /// <summary>
    /// Add package request message.
    /// </summary>
    public class AddPackageRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}