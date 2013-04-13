// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetUsersPackagesRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The get users packages request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Package
{
    /// <summary>
    /// The get users packages request.
    /// </summary>
    public class GetUsersPackagesRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets a value indicating whether include assembling.
        /// </summary>
        public bool IncludeAssembling { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether include paid.
        /// </summary>
        public bool IncludePaid { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether include sent.
        /// </summary>
        public bool IncludeSent { get; set; }
    }
}
