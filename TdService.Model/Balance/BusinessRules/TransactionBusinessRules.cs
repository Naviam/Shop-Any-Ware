using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TdService.Infrastructure.Domain;

namespace TdService.Model.Balance.BusinessRules
{
    public static class TransactionBusinessRules
    {
        public static readonly BusinessRule TransactionOperationAmountRequired =
           new BusinessRule("OperationAmount", ErrorCode.TransactionOperationAmountRequired.ToString());
    }
}
