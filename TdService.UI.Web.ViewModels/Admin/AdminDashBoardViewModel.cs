﻿namespace TdService.UI.Web.ViewModels.Admin
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
        public List<RoleViewModel> Roles { get; set; }
    }
}
