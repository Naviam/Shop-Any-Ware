using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TdService.Model.Membership
{
    public class MemberShipException:Exception
    {
        public MemberShipException(string message) : base(message)
        {
            
        }
    }
}
