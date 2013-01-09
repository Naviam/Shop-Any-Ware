namespace TdService.Services.Messaging.Membership
{
    using System;
    using System.Collections.Generic;

    public class GetUsersInRoleResponse
    {
        public class UserResponseModel
        {
            public int Id { get; set; }

            public string FullName { get; set; }

            public int OrdersCount { get; set; }

            public int PackagesCount { get; set; }

            public string Email { get; set; }

            public DateTime? LastAccessDate { get; set; }

            public List<int> Roles { get; set; }
        }

        public List<UserResponseModel> Users { get; set; }

        public int TotalCount { get; set; }
    }
}
