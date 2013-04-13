// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UsersPackagesViewModel.cs" company="Naviam">
//   Vadim Shaporov. 2013
// </copyright>
// <summary>
//   The users packages view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Package
{
    using System.Collections.Generic;

    /// <summary>
    /// The users packages view model.
    /// </summary>
    public class UsersPackagesViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the users packages.
        /// </summary>
        public List<UserPackageViewModel> UsersPackages { get; set; }
    }
}