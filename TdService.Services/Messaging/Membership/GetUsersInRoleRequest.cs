using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TdService.Services.Messaging.Membership
{
    public class GetUsersInRoleRequest
    {
        public int RoleId { get; set; }
        public int Skip { get; set; }
        public int Take{ get; set; }
    }
}
