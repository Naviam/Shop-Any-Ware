// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransactionBusinessRules.cs" company="Naviam">
//   Vadim Shaporov. 2013.
// </copyright>
// <summary>
//   Defines the TransactionBusinessRules type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Balance.BusinessRules
{
    using TdService.Infrastructure.Domain;

    /// <summary>
    /// The transaction business rules.
    /// </summary>
    public static class TransactionBusinessRules
    {
        /// <summary>
        /// The transaction operation amount required.
        /// </summary>
        public static readonly BusinessRule TransactionOperationAmountRequired =
           new BusinessRule("OperationAmount", ErrorCode.TransactionOperationAmountRequired.ToString());
    }
}
