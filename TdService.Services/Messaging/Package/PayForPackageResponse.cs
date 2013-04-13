// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PayForPackageResponse.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The pay for package response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Services.Messaging.Package
{
    using TdService.Services.Messaging.Package.Base;

    /// <summary>
    /// The pay for package response.
    /// </summary>
    public class PayForPackageResponse : BasePackageResponse
    {
        /// <summary>
        /// Gets or sets the wallet amount.
        /// </summary>
        public decimal WalletAmount { get; set; }
    }
}
