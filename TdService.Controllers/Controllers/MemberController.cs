﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MemberController.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Defines the MemberController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.Controllers
{
    using System;
    using System.Web.Mvc;

    using TdService.Infrastructure.Authentication;
    using TdService.Model.Orders;
    using TdService.Model.RFO;

    /// <summary>
    /// The controller that contains membership methods.
    /// </summary>
    public class MemberController : BaseController
    {
        /// <summary>
        /// Order repository.
        /// </summary>
        private readonly IOrderRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemberController"/> class.
        /// </summary>
        /// <param name="repo">
        /// The repo.
        /// </param>
        /// <param name="formsAuthentication">
        /// The forms Authentication.
        /// </param>
        public MemberController(IOrderRepository repo, IFormsAuthentication formsAuthentication)
            : base(formsAuthentication)
        {
            this.repository = repo;
        }

        /// <summary>
        /// The default view of an authenticated user.
        /// </summary>
        /// <returns>
        /// Returns the page with all information.
        /// </returns>
        public ActionResult Home()
        {
            return this.View();
        }

        /// <summary>
        /// Testing the new interface.
        /// </summary>
        /// <returns>
        /// Returns the page with the new interface.
        /// </returns>
        public ActionResult Dashboard()
        {
            this.repository.AddOrder(new Order(new OrderCreatedState())
            {
                CreatedDate = DateTime.UtcNow.Date,
                ReceivedDate = DateTime.UtcNow.Date
            });
            return this.View();
        }
    }
}