using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TdService.Services.Messaging.Membership
{
    public class AddUserToRoleRequest:RequestBase
    {
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}
