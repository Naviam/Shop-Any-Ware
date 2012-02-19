﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BalanceController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the BalanceController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Web.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// This controller contains methods to work with balance.
    /// </summary>
    public class BalanceController : Controller
    {
        /// <summary>
        /// Show the list of transactions.
        /// </summary>
        /// <returns>
        /// Returns view with the list of transactions.
        /// </returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}
