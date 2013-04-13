// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AdminDashBoardViewModel.cs" company="Naviam">
//   Vadim Shaporov. 2013.
// </copyright>
// <summary>
//   The admin dash board view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.UI.Web.ViewModels.Admin
{
    using System.Collections.Generic;
    using TdService.Resources.Views;
    using TdService.UI.Web.ViewModels.Account;

    /// <summary>
    /// The admin dash board view model.
    /// </summary>
    public class AdminDashBoardViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets the user filter validation message.
        /// </summary>
        public string UserFilterValidationMessage
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("UserFilterValiidationMessage");
            }
        }

        /// <summary>
        /// Gets the go to page index validation message.
        /// </summary>
        public string GoToPageIndexValidationMessage
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("GoToPageIndexValidationMessage");
            }
        }

        /// <summary>
        /// Gets the all roles translated.
        /// </summary>
        public string AllRolesTranslated
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("AllRoles");
            }
        }

        /// <summary>
        /// Gets the role management permissions error.
        /// </summary>
        public string RoleManagementPermissionsError
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("RoleManagementPermissionsError");
            }
        }

        /// <summary>
        /// Gets the shopper role cannot be assigned.
        /// </summary>
        public string ShopperRoleCannotBeAssigned
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("ShopperRoleCannotBeAssigned");
            }
        }

        /// <summary>
        /// Gets the cant modify own role.
        /// </summary>
        public string CantModifyOwnRole
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("CantModifyOwnRole");
            }
        }

        /// <summary>
        /// Gets the email is required.
        /// </summary>
        public string EmailIsRequired
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("UserValidationEmailRequired");
            }
        }

        /// <summary>
        /// Gets the email is incorrect.
        /// </summary>
        public string EmailIsIncorrect
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("UserValidationIncorrectEmail");
            }
        }

        /// <summary>
        /// Gets the first name is required.
        /// </summary>
        public string FirstNameIsRequired
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("UserValidationFirstNameRequired");
            }
        }

        /// <summary>
        /// Gets the last name is required.
        /// </summary>
        public string LastNameIsRequired
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("UserValidationLastNameIsRequired");
            }
        }

        /// <summary>
        /// Gets the password is required.
        /// </summary>
        public string PasswordIsRequired
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("UserValidationPasswordIsRequired");
            }
        }

        /// <summary>
        /// Gets the password should match.
        /// </summary>
        public string PasswordShouldMatch
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("UserValidationPasswordsShouldMatch");
            }
        }

        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        public List<RoleViewModel> Roles { get; set; }

        /// <summary>
        /// Gets or sets the member dash board url.
        /// </summary>
        public string MemberDashBoardUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether can modify user roles.
        /// </summary>
        public bool CanModifyUserRoles { get; set; }
    }
}