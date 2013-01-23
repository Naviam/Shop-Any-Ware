namespace TdService.UI.Web.ViewModels.Admin
{
    using System.Collections.Generic;
    using TdService.Resources.Views;
    using TdService.UI.Web.ViewModels.Account;

    public class AdminDashBoardViewModel : ViewModelBase
    {
        public string UserFilterValiidationMessage
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("UserFilterValiidationMessage");
            }
        }

        public string GoToPageIndexValidationMessage
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("GoToPageIndexValidationMessage");
            }
        }

        public string AllRolesTranslated
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("AllRoles");
            }
        }

        public string RoleManagementPermissionsError
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("RoleManagementPermissionsError");
            }
        }

        public string ShopperRoleCannotBeAssigned
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("ShopperRoleCannotBeAssigned");
            }
        }

        public string CantModifyOwnRole
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("CantModifyOwnRole");
            }
        }

        public string EmailIsRequired
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("UserValidationEmailRequired");
            }
        }

        public string EmailIsIncorrect
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("UserValidationIncorrectEmail");
            }
        }

        public string FirstNameIsRequired
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("UserValidationFirstNameRequired");
            }
        }

        public string LastNameIsRequired
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("UserValidationLastNameIsRequired");
            }
        }

        public string PasswordIsRequired
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("UserValidationPasswordIsRequired");
            }
        }

        public string PasswordShouldMatch
        {
            get
            {
                return AdminDashboardResources.ResourceManager.GetString("UserValidationPasswordsShouldMatch");
            }
        }

        public int UserId { get; set; }

        public List<RoleViewModel> Roles { get; set; }

        public string MemberDashBoardUrl { get; set; }

        public bool CanModifyUserRoles { get; set; }
    }
}
