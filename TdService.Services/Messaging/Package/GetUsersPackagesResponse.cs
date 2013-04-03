using System.Collections.Generic;

namespace TdService.Services.Messaging.Package
{
    public class GetUsersPackagesResponse:ResponseBase
    {
        public class UserPackage
        {
            public int UserId { get; set; }
            public string Email { get; set; }
            public string Status { get; set; }
            public string PackageName { get; set; }

            public int ItemsCount { get; set; }

            public string DispatchMethod { get; set; }

            public int PackageId { get; set; }
        }

        public List<UserPackage> UsersPackages { get; set; }
    }
}
