// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IReportRepository.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the IReportRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Model.Reports
{
    using System;
    using System.Collections.Generic;

    using TdService.Model.Orders;

    /// <summary>
    /// This interface contains report methods.
    /// </summary>
    public interface IReportRepository
    {
        /// <summary>
        /// Get sales report.
        /// </summary>
        /// <param name="periodStartDate">
        /// The period start date.
        /// </param>
        /// <param name="periodEndDate">
        /// The period end date.
        /// </param>
        /// <param name="filterExpression">
        /// The filter expression.
        /// </param>
        void GetSalesReport(DateTime periodStartDate, DateTime periodEndDate, string filterExpression);

        /// <summary>
        /// Get orders lose to end storage date.
        /// </summary>
        /// <returns>
        /// Collection of about to expire orders.
        /// </returns>
        IEnumerable<Order> GetOrdersCloseToEndStorageDate();
    }
}