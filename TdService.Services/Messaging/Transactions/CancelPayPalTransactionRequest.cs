using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TdService.Services.Messaging.Transactions
{
    public class CancelPayPalTransactionRequest:RequestBase
    {
        public string Token { get; set; }
    }
}
