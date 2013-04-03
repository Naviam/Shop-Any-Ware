using System;
using System.Collections.Generic;
using TdService.Resources;

namespace TdService.UI.Web.ViewModels.Package
{
    public class UsersPackagesViewModel : ViewModelBase
    {
        public class UserPackageViewModel
        {
            public int UserId { get; set; }

            public string Email { get; set; }

            public string Status { get; set; }

            public string PackageName { get; set; }

            public int ItemsCount { get; set; }

            public string DispatchMethod { get; set; }

            public string DispatchMethodTranslated
            {
                get
                {
                    return DispatchMethods.ResourceManager.GetString(this.DispatchMethod);
                }
            }

            public int PackageId { get; set; }
        }
        public List<UserPackageViewModel> UsersPackages { get; set; }
    }
}
