using System;
using System.Collections.Generic;

namespace TdService.UI.Web.ViewModels.Package
{
    public class UsersPackagesViewModel : ViewModelBase
    {
        public class UserPackageViewModel
        {
            public int Id { get; set; }

            public string Email { get; set; }

            public string Status { get; set; }
        }
        public List<UserPackageViewModel> UsersPackages { get; set; }
    }
}
