using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TdService.Services.Messaging.Membership
{
    public class GetAllRolesResponse:ResponseBase
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the role name.
        /// </summary>
        public string Name { get; set; }
    }
}
