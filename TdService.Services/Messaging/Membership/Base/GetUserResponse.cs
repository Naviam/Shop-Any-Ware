using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TdService.Services.Messaging.Membership.Base
{
    public abstract class GetUserResponse:ResponseBase
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int OrdersCount { get; set; }

        public int PackagesCount { get; set; }

        public string Email { get; set; }

        public DateTime? LastAccessDate { get; set; }

        public List<int> Roles { get; set; }
    }
}
