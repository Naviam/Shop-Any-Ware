// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="TdService">
//   Vitali Hatalski. 2012.
// </copyright>
// <summary>
//   Main application entry point.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TdService.TestConsole
{
    using System;
    using Model;
    using Model.Orders;

    using TdService.Data.SqlRepository;

    /// <summary>
    /// Main application entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            var order = new Order(new OrderNewState())
                            {
                                OrderNumber = "4534523d",
                                Retailer = new Retailer(),
                                TrackingNumber = "1Zdrr844353459",
                                ReceivedDate = DateTime.Now,
                                Weight = new Weight { Pounds = 5, Ounces = 1 }
                            };
            var repo = new OrderRepository();
            repo.AddOrder(order);
        }
    }
}