using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TdService.Services.Messaging.Transactions
{
    public class GetTransactionsRequest:RequestBase
    {
        /// <summary>
        /// Gets or sets the take.
        /// </summary>
        public int Take { get; set; }
    }
}
