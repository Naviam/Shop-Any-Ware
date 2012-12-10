using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TdService.Services.Messaging.Transactions
{
    public class ConfirmPayPalTransactionRequest:RequestBase
    {
        /// <summary>
        /// Gets or sets token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets payer id
        /// </summary>
        public string PayerId{ get; set; }
    }
}
