// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeUserCultureRequest.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The change user culture request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Membership
{
    /// <summary>
    /// The change user culture request.
    /// </summary>
    public class ChangeUserCultureRequest : RequestBase
    {
        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        public string Culture { get; set; }
    }
}
