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
        void GetSalesReport(DateTime periodStartDate, DateTime periodEndDate, string filterExpression);

        IEnumerable<Order> GetOrdersCloseToEndStorageDate();
    }
}