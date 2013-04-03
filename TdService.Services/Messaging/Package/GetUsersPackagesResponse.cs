using System.Collections.Generic;

namespace TdService.Services.Messaging.Package
{
    public class GetUsersPackagesResponse:ResponseBase
    {
        public class UserPackage
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string Status { get; set; }
        }

        public List<UserPackage> UsersPackages { get; set; }
    }
}
