// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserPackageViewModel.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The user package view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Package
{
    using TdService.Resources;

    /// <summary>
    /// The user package view model.
    /// </summary>
    public class UserPackageViewModel
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the package name.
        /// </summary>
        public string PackageName { get; set; }

        /// <summary>
        /// Gets or sets the items count.
        /// </summary>
        public int ItemsCount { get; set; }

        /// <summary>
        /// Gets or sets the dispatch method.
        /// </summary>
        public string DispatchMethod { get; set; }

        /// <summary>
        /// Gets the dispatch method translated.
        /// </summary>
        public string DispatchMethodTranslated
        {
            get
            {
                return DispatchMethods.ResourceManager.GetString(this.DispatchMethod);
            }
        }

        /// <summary>
        /// Gets or sets the package id.
        /// </summary>
        public int PackageId { get; set; }
    }
}