namespace TdService.Services.Messaging.Membership
{
    using System;

    public class GetUsersInRoleResponse
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int OrdersCount { get; set; }

        public int PackagesCount { get; set; }

        public string Email { get; set; }

        public DateTime? LastAccessDate { get; set; }
    }
}
