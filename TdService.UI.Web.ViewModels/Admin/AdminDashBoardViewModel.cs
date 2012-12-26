namespace TdService.UI.Web.ViewModels.Admin
{
    using System.Collections.Generic;
    using TdService.UI.Web.ViewModels.Account;

    public class AdminDashBoardViewModel : ViewModelBase
    {
        public List<RoleViewModel> Roles { get; set; }
    }
}
